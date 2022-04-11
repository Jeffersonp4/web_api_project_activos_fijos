using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_project_activos_fijos.Helpers;
using web_api_project_activos_fijos.Repositories;

namespace web_api_project_activos_fijos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController
        <TEntity, TDTO, TDTOCreacion, TRepository> : ControllerBase
        where TEntity : class, IId
        where TDTO : class
        where TDTOCreacion : class
        where TRepository : IRepository<TEntity>
    {
        protected readonly TRepository _repository;
        protected readonly IMapper _mapper;
        public CustomBaseController(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: api/[controller]
        [HttpGet]
        public async Task<ActionResult<PaginationGeneric<TDTO>>> Get([FromQuery] string[] includes, string typeOrder = "asc", int page = 1, int registerForPage = 10)
        {
            PaginationGeneric<TEntity> entitiePagination = await _repository.GetAll(includes, typeOrder, page, registerForPage);

            var dtos = _mapper.Map<PaginationGeneric<TDTO>>(entitiePagination);
            return dtos;
        }

        // GET: api/[controller]/id

        [HttpGet("{id}")]

        public async Task<ActionResult<TDTO>> Get(int id, [FromQuery] string[] includes)
        {
            var entity = await _repository.Get(id, includes);

            if (entity == null)
            {
                return NotFound($"Este id -> {id} no existe");
            }
            var dto = _mapper.Map<TDTO>(entity);
            return dto;
        }

        // Put: api/[controller]/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TDTOCreacion tDTOCreacion)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(tDTOCreacion);
                entity.Id = id;
                var changed = await _repository.Update(entity);
                if (changed == null)
                {
                    return NotFound($"Este id -> {id} no existe");
                }
                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {

                return BadRequest($"Lo sentimos algo salio mal: {ex.Message}");
            }
        }

        // POST: api/[controller]

        [HttpPost]

        public async Task<ActionResult<TEntity>> Post(TDTOCreacion creacionDTO)
        {
            BaseResponse res = new();
            try
            {
                var entity = _mapper.Map<TEntity>(creacionDTO);
                await _repository.Add(entity);
                var dtoLectura = _mapper.Map<TDTO>(entity);

                return CreatedAtAction("Get", new { id = entity.Id }, dtoLectura);
            }
            catch (Exception e)
            {

                res.Message = "Ha ocurrido un error!";
                res.Ok = false;
                res.Data = new { ErrorDescription = e.Message, HelpLink = e.HelpLink, Exception = e.InnerException };
                return BadRequest(res);
            }
        }

        // PATCH: api/[controller]/5

        [HttpPatch]

        public async Task<ActionResult> Patch(int id, JsonPatchDocument<TEntity> patchDoc)
        {
            if (patchDoc == null)
            {
                return BadRequest("No es un formato Valido");

            }

            var entityEdit = await _repository.Get(id, null);
            if (entityEdit == null)
            {
                return NotFound($"Este id -> {id} no existe");
            }
            patchDoc.ApplyTo(entityEdit, ModelState);

            var isValid = TryValidateModel(entityEdit);

            if (!isValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                await _repository.Save();
                return NoContent();
            }
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await _repository.Delete(id);
            if (entity == null)
            {
                return NotFound($"Este id -> {id} no existe.");
            }
            return NoContent();
        }

    }
}

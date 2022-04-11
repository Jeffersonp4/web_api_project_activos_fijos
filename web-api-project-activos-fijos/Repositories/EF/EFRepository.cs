using Microsoft.EntityFrameworkCore;
using web_api_project_activos_fijos.Helpers;

namespace web_api_project_activos_fijos.Repositories.EF
{

        public class EFRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IId
        where TContext : DbContext
        {
            private readonly TContext _dataContext;
            public EFRepository(TContext _dataContext)
            {
                this._dataContext = _dataContext;
            }

            public async Task<TEntity> Add(TEntity entity)
            {
                _dataContext.Set<TEntity>().Add(entity);
                await _dataContext.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> Delete(int id)
            {
                var entity = await _dataContext.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return entity!;
                }
                _dataContext.Set<TEntity>().Remove(entity);
                await _dataContext.SaveChangesAsync();
                return entity;
            }

            public async Task<TEntity> Get(int id, string[] includes)
            {
                var entities = _dataContext!.Set<TEntity>().AsQueryable();
                includes.ToList().ForEach(include =>
                {
                    if (!string.IsNullOrEmpty(include))
                        entities = entities.Include(include);

                });

                TEntity entitie = await entities.FirstOrDefaultAsync(x => x.Id == id);
                return entitie!;
            }

            public async Task<PaginationGeneric<TEntity>> GetAll(string[] includes, string typeOrder, int page, int registerForpage)
            {
                List<TEntity> _TEntities;
                PaginationGeneric<TEntity> _PaginationTEntity;
                int _totalRegisters = 0;
                int _totalPages = 0;

                // Recuperamos el 'DbSet' completo

                var entities = _dataContext.Set<TEntity>().AsQueryable();
                includes.ToList().ForEach(include =>
                {
                    if (!string.IsNullOrEmpty(include))
                        entities = entities.Include(include);
                });

                _TEntities = await entities.ToListAsync();

                if (typeOrder.ToLower() == "desc")
                    _TEntities = _TEntities.OrderByDescending(x => x.Id).ToList();
                else if (typeOrder.ToLower() == "asc")
                    _TEntities = _TEntities.OrderBy(x => x.Id).ToList();

                // Número total de registros de la tabla Customers
                _totalRegisters = _TEntities.Count();

                // Obtenemos la 'página de registros' de la tabla Customers
                _TEntities = _TEntities.Skip((page - 1) * registerForpage)
                                                 .Take(registerForpage)
                                                 .ToList();
                // Número total de páginas de la tabla
                _totalPages = (int)Math.Ceiling((double)_totalRegisters / registerForpage);

                // Instanciamos la 'Clase de paginación' y asignamos los nuevos valores
                _PaginationTEntity = new PaginationGeneric<TEntity>()
                {
                    RegistrosPorPagina = registerForpage,
                    TotalRegistros = _totalRegisters,
                    TotalPaginas = _totalPages,
                    PaginaActual = page,
                    TipoOrdenActual = typeOrder,
                    Resultado = _TEntities
                };

                return _PaginationTEntity;
            }

            public async Task<TEntity> Update(TEntity entity)
            {
                var existe = await _dataContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);
                if (existe == null)
                {
                    return null;
                }
                else
                {
                    _dataContext.Entry(entity).State = EntityState.Modified;
                    await _dataContext.SaveChangesAsync();
                    return entity;
                }
            }

            public async Task<int> Save()
            {
                await _dataContext.SaveChangesAsync();
                return 1;
            }

        }
    }


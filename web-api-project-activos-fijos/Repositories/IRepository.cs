using web_api_project_activos_fijos.Helpers;

namespace web_api_project_activos_fijos.Repositories
{
    public interface IRepository<T> where T : class, IId
    {
        Task<PaginationGeneric<T>> GetAll(string[] includes, string typeOrder, int page, int registerForpage);
        Task<T> Get(int id, string[] includes);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<int> Save();
        Task<T> Delete(int id);
    }
}

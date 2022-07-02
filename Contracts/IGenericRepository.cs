namespace LeaveManagement.Web.Contracts
{
    public interface IGenericRepository<T> 
        where T : class
    {
       Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<bool> Exists(int id);

        Task DeleteAsync(int id);
        Task UpdateAsync(T entity);
        Task<T> AddAsync(T entity);

    }
}

using E_CommerceAPI.Models.Interfaces;

namespace E_CommerceAPI.Repository
{
    public interface IGenericRepository<T> where T : class, IEntity
    {
        Task<T?> GetAsync(Guid Id);
        Task CreateAsync(T entity);
        Task<List<T>?> GetAllAsync();

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);



    }
}

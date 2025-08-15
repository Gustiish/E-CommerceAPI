using E_CommerceAPI.Database;
using E_CommerceAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceAPI.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _set;
        private readonly ILogger<GenericRepository<T>> _logger;

        public GenericRepository(ApplicationDbContext context, ILogger<GenericRepository<T>> logger)
        {
            _context = context;
            _set = _context.Set<T>();
            _logger = logger;

        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                _logger.LogInformation("Added a new {entity}", entity.GetType().Name);
                await _set.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to add a new {entity} with id {entityId}", entity.GetType().Name, entity.Id);
            }
        }

        public async Task DeleteAsync(Guid Id)
        {
            try
            {
                _logger.LogInformation("Deleted a {entity} with id {entityId}", )
            }
            catch (Exception e)
            {

            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetAsync(Guid Id)
        {
            try
            {
                _logger.LogInformation($"Retrieved an {nameof} with id: {Id}")
            }
        }

        public async Task UpdateAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

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

        public async Task DeleteAsync(T entity)
        {
            try
            {
                _logger.LogInformation("Deleted a {entity}", entity.GetType().Name);
                _set.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to delete {entity}", entity.GetType().Name);
            }
        }

        public async Task<List<T>?> GetAllAsync()
        {
            try
            {
                _logger.LogInformation("Retrieved all {set}", _set.GetType().Name);
                return await _set.ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve all {set}", _set.GetType().Name);
                return null;
            }
        }

        public async Task<T?> GetAsync(Guid Id)
        {
            try
            {
                _logger.LogInformation("Retrieved an {Id} with id: {Id}", Id, Id.GetType().Name);
                return await _set.FindAsync(Id);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to retrieve an {Id} with {Id}", Id.GetType().Name, Id);
                return null;
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                _logger.LogInformation("Updated an {entity} with {id}", entity.GetType().Name, entity.Id);
                _set.Update(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to update an {entity} with {id}", entity.GetType().Name, entity.Id);
            }
        }
    }
}

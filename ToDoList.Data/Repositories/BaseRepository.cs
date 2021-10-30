using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.Domain.Shared.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> entities;
        private readonly ILogger<T> _logger;

        public BaseRepository(DataContext context, ILogger<T> logger)
        {
            _context = context;
            entities = context.Set<T>();
            _logger = logger;
        }

        public async Task Create(T entity)
        {
            await entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            _logger.LogWarning("INSERT: {properties}", JsonSerializer.Serialize(entity));
        }

        public async Task Delete(T entity)
        {
            entities.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogWarning("DELETE: {properties}", JsonSerializer.Serialize(entity));
        }

        public async Task<ICollection<T>> GetAll()
        {
            var data = await entities.ToListAsync();
            _logger.LogWarning("SELECT: {properties}", JsonSerializer.Serialize(data));
            return data;
        }

        public async Task<T> GetById(int id)
        {
            var data = await entities.FindAsync(id);
            _logger.LogWarning("SELECT: {properties}", JsonSerializer.Serialize(data));
            return data;
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _logger.LogWarning("UPDATE: {properties}", JsonSerializer.Serialize(entity));
        }
    }
}

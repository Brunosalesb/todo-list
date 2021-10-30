using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System.Threading.Tasks;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.Data.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<ToDo> _logger;

        public ToDoRepository(DataContext context, ILogger<ToDo> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<ToDo> GetByIdAsNoTracking(int id)
        {
            var data = await _context.ToDo.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            _logger.LogWarning("SELECT: {properties}", JsonSerializer.Serialize(data));
            return data;
        }
    }
}

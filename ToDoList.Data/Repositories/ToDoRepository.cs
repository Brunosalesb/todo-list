using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ToDoList.Data.Repositories;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.Data.Repositories
{
    public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
    {
        private readonly DataContext _context;
        public ToDoRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ToDo> GetByIdAsNoTracking(int id)
        {
            return await _context.ToDo.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

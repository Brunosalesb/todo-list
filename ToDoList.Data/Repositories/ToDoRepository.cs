using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.Infra.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly DataContext _context;
        public ToDoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task Create(ToDo toDo)
        {
            await _context.ToDo.AddAsync(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ToDo toDo)
        {
            _context.ToDo.Remove(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<ToDo>> GetAll()
        {
            return await _context.ToDo.AsNoTracking().ToListAsync();
        }

        public async Task<ToDo> GetById(int id)
        {
            return await _context.ToDo.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ToDo> GetByIdAsNoTracking(int id)
        {
            return await _context.ToDo.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(ToDo toDo)
        {
            _context.Entry(toDo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

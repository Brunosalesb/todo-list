using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infra.Mappings;

namespace ToDoList.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoMap());
        }
    }
}

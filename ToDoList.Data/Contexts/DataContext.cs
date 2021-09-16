using Microsoft.EntityFrameworkCore;
using ToDoList.Data.Mappings;
using ToDoList.Domain.SqlServer.Entities;

namespace ToDoList.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<ToDo> ToDo { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ToDoMap());
            modelBuilder.ApplyConfiguration(new UserMap());
        }
    }
}

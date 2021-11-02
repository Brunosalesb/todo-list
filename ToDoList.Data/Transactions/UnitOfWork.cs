using ToDoList.Domain.Shared.Transactions;
using ToDoList.Infra.Contexts;

namespace ToDoList.Data.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {
            //do nothing, the transaction will die by EF
        }
    }
}

namespace ToDoList.Domain.Shared.Transactions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
    }
}

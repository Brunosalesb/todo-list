using System.Linq;
using ToDoList.Domain.Helpers;
using ToDoList.Domain.SqlServer.Contracts.Request.User;
using ToDoList.Domain.SqlServer.Contracts.Response.User;
using ToDoList.Domain.SqlServer.Entities;
using ToDoList.Domain.SqlServer.Interfaces;
using ToDoList.Infra.Contexts;

namespace ToDoList.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public GetUserAuthResponse GetByEmailAndPassword(CreateUserRequest request)
        {
            return _context.User.FirstOrDefault(x => x.Email == request.Email && x.Password == StringHelper.EncryptPassword(request.Password)).MapGetUserAuthResponse();
        }
    }
}

using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Json;
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
        private readonly ILogger<User> _logger;
        public UserRepository(DataContext context, ILogger<User> logger) : base(context, logger)
        {
            _context = context;
            _logger = logger;
        }

        public GetUserAuthResponse GetByEmailAndPassword(CreateUserRequest request)
        {
            var user = _context.User.FirstOrDefault(x => x.Email == request.Email && x.Password == StringHelper.EncryptPassword(request.Password));
            if (user == null) return null;

            var data = user.MapGetUserAuthResponse();
            _logger.LogWarning("AUTH ATTEMPT: {properties}", JsonSerializer.Serialize(data));

            return data;
        }
    }
}

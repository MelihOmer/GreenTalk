using GreenTalk.Application.Interfaces.Services;
using GreenTalk.Core.Entities;
using GreenTalk.Core.Interfaces.Repository;

namespace GreenTalk.Service.Services
{
    public class UserService : Service<User>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}

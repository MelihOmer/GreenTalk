using GreenTalk.Core.Entities;

namespace GreenTalk.Core.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}

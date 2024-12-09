namespace GreenTalk.Core.Interfaces.Jwt
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId,string username);
    }
}

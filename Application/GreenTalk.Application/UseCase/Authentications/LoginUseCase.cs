using GreenTalk.Application.DTOs.AuthDTOs;
using GreenTalk.Core.Interfaces.Jwt;
using GreenTalk.Core.Interfaces.Repository;

namespace GreenTalk.Application.UseCase.Authentications
{
    public class LoginUseCase
    {
        IUserRepository _userRepository;
        IJwtTokenGenerator _jwtTokenGenerator;

        public LoginUseCase(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<LoginResponseDto> ExecuteAsync(LoginRequestDto loginRequestDto)
        {

            var user = await _userRepository.GetByUsernameAsync(loginRequestDto.Username);
            if (user is null || VerifyPassword(loginRequestDto.Password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid username or password");

            var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Username);
            return new LoginResponseDto
            {
                Token = token,
                Username = user.Username
            };
        }
        private bool VerifyPassword(string password, string passwordHash)
        {
            return password == passwordHash;
        }
    }
}

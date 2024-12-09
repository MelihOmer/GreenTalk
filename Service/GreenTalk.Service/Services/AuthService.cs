using GreenTalk.Application.DTOs.AuthDTOs;
using GreenTalk.Application.UseCase.Authentications;

namespace GreenTalk.Service.Services
{
    public class AuthService
    {
        private readonly LoginUseCase _loginUseCase;

        public AuthService(LoginUseCase loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto requestDto)
        {
            return await _loginUseCase.ExecuteAsync(requestDto);
        }
    }
}

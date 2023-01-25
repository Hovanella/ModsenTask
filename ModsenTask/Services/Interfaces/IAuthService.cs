using ModsenTask.Dtos;

namespace ModsenTask.Services.Interfaces;

public interface IAuthService
{
    public Task<string> Login(LoginDto loginDto);

    public Task<RegisteredOrganizerDto> Register(RegisterOrganizerDto registerOrganizerDto);
}
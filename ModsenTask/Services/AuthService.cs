using System.Security.Authentication;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using ModsenTask.Dtos;
using ModsenTask.Models;
using ModsenTask.Repositories.Interfaces;
using ModsenTask.Services.Interfaces;

namespace ModsenTask.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    private readonly IMapper _mapper;
    private readonly IOrganizerRepository _organizerRepository;

    public AuthService(IOrganizerRepository organizerRepository, IMapper mapper, IConfiguration configuration)
    {
        _organizerRepository = organizerRepository;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<string> Login(LoginDto loginDto)
    {
        var organizer = await _organizerRepository.GetOrganizerByNameAsync(loginDto.Name) ??
                        throw new InvalidCredentialException("No organizer with this name");

        if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, organizer.Password))
            throw new InvalidCredentialException("Wrong password");

        var handler = new JsonWebTokenHandler();

        var key = Encoding.UTF8.GetBytes(_configuration.GetSection("ApplicationSettings").GetValue<string>("Secret") ??
                                         string.Empty);

        var token = handler.CreateToken(new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("sub", organizer.Id.ToString()),
                new Claim("name", organizer.Name)
            }),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            Expires = DateTime.Now.AddDays(1)
        });

        return token;
    }

    public async Task<RegisteredOrganizerDto> Register(RegisterOrganizerDto registerOrganizerDto)
    {
        var organizer = _mapper.Map<Organizer>(registerOrganizerDto);
        organizer.Password = BCrypt.Net.BCrypt.HashPassword(registerOrganizerDto.Password);

        var createdOrganizer = await _organizerRepository.CreateOrganizerAsync(organizer);
        return _mapper.Map<RegisteredOrganizerDto>(createdOrganizer);
    }
}
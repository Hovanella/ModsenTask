using Swashbuckle.AspNetCore.Annotations;

namespace ModsenTask.Dtos;

[SwaggerSchema("A request body to login organizer")]
public class LoginDto
{
    public string Name { get; set; } = default!;
    public string Password { get; set; } = default!;
}
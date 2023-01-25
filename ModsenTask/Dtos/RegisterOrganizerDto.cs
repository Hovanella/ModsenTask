using Swashbuckle.AspNetCore.Annotations;

namespace ModsenTask.Dtos;

[SwaggerSchema("A request body to register a new organizer")]
public class RegisterOrganizerDto
{
    public string Name { get; set; } = default!;
    public string Password { get; set; } = default!;
}
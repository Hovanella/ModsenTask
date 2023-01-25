using Swashbuckle.AspNetCore.Annotations;

namespace ModsenTask.Dtos;

[SwaggerSchema("A response body for created organizer")]
public class RegisteredOrganizerDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string Password { get; set; } = default!;
}
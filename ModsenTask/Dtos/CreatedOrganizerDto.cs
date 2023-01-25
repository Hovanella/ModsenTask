using Swashbuckle.AspNetCore.Annotations;

namespace ModsenTask.Dtos;

[SwaggerSchema("The response body for created organizer")]
public class CreatedOrganizerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public byte[] Password { get; set; } = default!;
}
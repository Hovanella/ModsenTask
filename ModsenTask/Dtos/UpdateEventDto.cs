using Swashbuckle.AspNetCore.Annotations;

namespace ModsenTask.Dtos;

[SwaggerSchema("A request body to update an event")]
public class UpdateEventDto
{
    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public DateTime Date { get; set; }

    public string Location { get; set; } = default!;

    public string SpeakerName { get; set; } = default!;
}
namespace ModsenTask.Dtos;

public class CreatedOrganizerDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;

    public byte[] Password { get; set; } = default!;
}
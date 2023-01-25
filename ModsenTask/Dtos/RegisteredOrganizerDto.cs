namespace ModsenTask.Dtos;

public class RegisteredOrganizerDto
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string Password { get; set; } = default!;
}
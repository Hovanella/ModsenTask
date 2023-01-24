namespace ModsenTask.Domain.Models;

public class Speaker
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public ICollection<Event> Events { get; set; } = default!;
}
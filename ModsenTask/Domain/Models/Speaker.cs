namespace ModsenTask.Domain.Models;

public class Speaker
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public ICollection<Event> Events { get; set; }
}
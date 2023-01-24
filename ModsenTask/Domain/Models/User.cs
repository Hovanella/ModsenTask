
namespace ModsenTask.Domain.Models;

public class User
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public Role Role { get; set; }
    public Guid RoleId { get; set; }
    
    public ICollection<Event> Events { get; set; }
}
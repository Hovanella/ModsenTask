using System.Collections;

namespace ModsenTask.Domain.Models;

public class Role
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public ICollection<User> Users { get; set; }
}
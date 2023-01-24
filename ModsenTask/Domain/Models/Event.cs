using System.ComponentModel.DataAnnotations.Schema;

namespace ModsenTask.Domain.Models;

public class Event
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public User Organizer { get; set; }
    public Guid OrganizerId { get; set; }
    
    public Speaker Speaker { get; set; }
    public Guid SpeakerId { get; set; }
    
    public DateTime Date { get; set; }
    
    public string Location { get; set; }
}
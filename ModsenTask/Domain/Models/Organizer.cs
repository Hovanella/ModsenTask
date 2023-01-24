using System.ComponentModel.DataAnnotations.Schema;

namespace ModsenTask.Domain.Models;

[Table("Organizers")]
public class Organizer
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = default!;

    public string Password { get; set; } = default!;

    public ICollection<Event> Events { get; set; } = default!;
}
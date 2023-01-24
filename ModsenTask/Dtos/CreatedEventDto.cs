namespace ModsenTask.Dtos;

public class CreatedEventDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;

    public string Description { get; set; }  = default!;

    public DateTime Date { get; set; }

    public string Location { get; set; }  = default!;
 
    public string SpeakerName { get; set; }  = default!;
    
    public string OrganizerName { get; set; }  = default!;
}
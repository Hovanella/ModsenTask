namespace ModsenTask.Dtos;

public class EventViewDto
{
    public string Name { get; set; } = default!;

    public string Description { get; set; }  = default!;

    public DateTime Date { get; set; }

    public string Location { get; set; }  = default!;
 
    public string SpeakerName { get; set; }  = default!;
    
    public string OrganizerName { get; set; }  = default!;
}
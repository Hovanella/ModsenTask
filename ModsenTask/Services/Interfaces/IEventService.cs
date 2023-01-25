using ModsenTask.Dtos;

namespace ModsenTask.Services.Interfaces;

public interface IEventService
{
    Task<IEnumerable<EventViewDto>> GetAllEventsAsync();

    Task<EventViewDto?> GetEventByIdAsync(Guid id);

    Task<CreatedEventDto> CreateEventAsync(CreateEventDto newCreateEvent);

    Task<UpdatedEventDto> UpdateEventAsync(Guid id, UpdateEventDto updateEventDto);

    Task<DeletedEventDto> DeleteEventAsync(Guid id);
}
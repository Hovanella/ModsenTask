using ModsenTask.Domain.Models;

namespace ModsenTask.Repositories.Interfaces;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetAllEventsAsync();

    Task<Event?> GetEventByIdAsync(Guid id);

    Task<Event> CreateEventAsync(Event newEvent);

    Task<Event> UpdateEventAsync(Event eventToUpdate, Event updatedEvent);
    
    Task<Event> DeleteEventAsync(Event eventToDelete);
}
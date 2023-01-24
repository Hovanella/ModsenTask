using Microsoft.EntityFrameworkCore;
using ModsenTask.Data;
using ModsenTask.Domain.Models;
using ModsenTask.Repositories.Interfaces;

namespace ModsenTask.Repositories;

public class EventRepository : IEventRepository
{
    private readonly DataContext _context;
    
    public EventRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.Include(e => e.Organizer).Include(e=>e.Speaker).ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(Guid id)
    {
        return await _context.Events.Include(e => e.Organizer).Include(e=>e.Speaker).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Event> CreateEventAsync(Event newEvent)
    {
        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
        return _context.Entry(newEvent).Entity;
    }

    public async Task<Event> UpdateEventAsync(Event eventToUpdate, Event updatedEvent)
    {
        _context.Entry(eventToUpdate).CurrentValues.SetValues(updatedEvent);
        await _context.SaveChangesAsync();
        return _context.Entry(eventToUpdate).Entity;
    }

    public async Task<Event> DeleteEventAsync(Event eventToDelete)
    {
        var deletedEvent = _context.Events.Remove(eventToDelete).Entity;
        await _context.SaveChangesAsync();
        return deletedEvent;
    }
}
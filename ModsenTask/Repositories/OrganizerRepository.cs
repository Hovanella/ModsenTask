using Microsoft.EntityFrameworkCore;
using ModsenTask.Data;
using ModsenTask.Models;
using ModsenTask.Repositories.Interfaces;

namespace ModsenTask.Repositories;

public class OrganizerRepository : IOrganizerRepository
{
    private readonly DataContext _context;

    public OrganizerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Organizer?> GetOrganizerByNameAsync(string name)
    {
        return await _context.Organizers.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Organizer> CreateOrganizerAsync(Organizer organizer)
    {
        var created = (await _context.Organizers.AddAsync(organizer)).Entity;
        await _context.SaveChangesAsync();
        return created;
    }

    public Task<Organizer?> GetOrganizerByIdAsync(Guid organizerId)
    {
        return _context.Organizers.FirstOrDefaultAsync(x => x.Id == organizerId);
    }
}
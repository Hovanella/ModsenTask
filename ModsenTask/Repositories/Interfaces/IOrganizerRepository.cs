using ModsenTask.Models;

namespace ModsenTask.Repositories.Interfaces;

public interface IOrganizerRepository
{
    public Task<Organizer?> GetOrganizerByNameAsync(string name);
    public Task<Organizer> CreateOrganizerAsync(Organizer organizer);
    public Task<Organizer?> GetOrganizerByIdAsync(Guid organizerId);
}
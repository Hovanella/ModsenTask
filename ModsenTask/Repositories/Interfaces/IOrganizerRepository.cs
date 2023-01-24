using ModsenTask.Domain.Models;

namespace ModsenTask.Repositories.Interfaces;

public interface IOrganizerRepository
{
    public Task<Organizer> GetOrganizerByIdAsync(Guid id);
}
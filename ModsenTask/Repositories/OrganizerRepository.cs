using ModsenTask.Domain.Models;
using ModsenTask.Repositories.Interfaces;

namespace ModsenTask.Repositories;

public class OrganizerRepository : IOrganizerRepository
{
    public Task<Organizer> GetOrganizerByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Organizer> GetOrganizerByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
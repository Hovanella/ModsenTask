using Microsoft.EntityFrameworkCore;
using ModsenTask.Data;
using ModsenTask.Models;
using ModsenTask.Repositories.Interfaces;

namespace ModsenTask.Repositories;

public class SpeakerRepository : ISpeakerRepository
{
    private readonly DataContext _context;

    public SpeakerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Speaker?> GetSpeakerByNameAsync(string name)
    {
        return await _context.Speakers.FirstOrDefaultAsync(x => x.Name == name);
    }

    public async Task<Speaker> CreateSpeakerAsync(Speaker speaker)
    {
        return (await _context.Speakers.AddAsync(speaker)).Entity;
    }
}
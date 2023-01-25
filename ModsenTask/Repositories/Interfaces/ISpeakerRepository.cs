using ModsenTask.Models;

namespace ModsenTask.Repositories.Interfaces;

public interface ISpeakerRepository
{
    Task<Speaker?> GetSpeakerByNameAsync(string name);

    Task<Speaker> CreateSpeakerAsync(Speaker speaker);
}
using AutoMapper;
using ModsenTask.Controllers;
using ModsenTask.Domain.Models;
using ModsenTask.Dtos;
using ModsenTask.Repositories.Interfaces;
using ModsenTask.Services.Interfaces;

namespace ModsenTask.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IOrganizerRepository _organizerRepository;
    private readonly ISpeakerRepository _speakerRepository;
    private readonly IMapper _mapper;

    public EventService(IEventRepository eventRepository, ISpeakerRepository speakerRepository,
        IOrganizerRepository organizerRepository, IMapper mapper)
    {
        _eventRepository = eventRepository;
        _speakerRepository = speakerRepository;
        _organizerRepository = organizerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EventViewDto>> GetAllEventsAsync()
    {
        var events = await _eventRepository.GetAllEventsAsync();
        return _mapper.Map<IEnumerable<EventViewDto>>(events);
        
    }

    public async Task<EventViewDto?> GetEventByIdAsync(Guid id)
    {
        return _mapper.Map<EventViewDto>(await _eventRepository.GetEventByIdAsync(id));
    }

    public async Task<CreatedEventDto> CreateEventAsync(CreateEventDto newCreateEventDto)
    {
        var speaker = await _speakerRepository.GetSpeakerByNameAsync(newCreateEventDto.SpeakerName) ??
                      await _speakerRepository.CreateSpeakerAsync(new Speaker
                      {
                          Name = newCreateEventDto.SpeakerName
                      });

        var organizer = (await _eventRepository.GetAllEventsAsync()).ToList()[0].Organizer;

        var newEvent = _mapper.Map<Event>(newCreateEventDto);
        newEvent.Speaker = speaker;
        newEvent.Organizer = organizer;
        
        return _mapper.Map<CreatedEventDto>(await _eventRepository.CreateEventAsync(newEvent));
    }

    public async Task<UpdatedEventDto> UpdateEventAsync(Guid id, UpdateEventDto updateEventDto)
    {
        var eventToUpdate = await _eventRepository.GetEventByIdAsync(id) ??
                            throw new BadHttpRequestException($"Event with id {id} not found");
        
        var updatedEvent = _mapper.Map<Event>(updateEventDto);
        var updatedSpeaker = await _speakerRepository.GetSpeakerByNameAsync(updateEventDto.SpeakerName) ??
                             await _speakerRepository.CreateSpeakerAsync(new Speaker
                             {
                                 Name = updateEventDto.SpeakerName
                             });
        updatedEvent.Id = id;
        updatedEvent.SpeakerId = updatedSpeaker.Id;
        updatedEvent.OrganizerId = eventToUpdate.OrganizerId;

        return _mapper.Map<UpdatedEventDto>( await _eventRepository.UpdateEventAsync(eventToUpdate,updatedEvent));
    }

    public async Task<DeletedEventDto> DeleteEventAsync(Guid id)
    {
        var eventToUpdate = await _eventRepository.GetEventByIdAsync(id) ??
                            throw new BadHttpRequestException($"Event with id {id} not found");
        
        return _mapper.Map<DeletedEventDto>(await _eventRepository.DeleteEventAsync(eventToUpdate));
    }
}
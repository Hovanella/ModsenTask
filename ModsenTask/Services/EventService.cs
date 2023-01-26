using AutoMapper;
using ModsenTask.Dtos;
using ModsenTask.Exceptions;
using ModsenTask.Models;
using ModsenTask.Repositories.Interfaces;
using ModsenTask.Services.Interfaces;

namespace ModsenTask.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;
    private readonly IOrganizerRepository _organizerRepository;
    private readonly ISpeakerRepository _speakerRepository;

    public EventService(IEventRepository eventRepository, ISpeakerRepository speakerRepository,
        IOrganizerRepository organizerRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _eventRepository = eventRepository;
        _speakerRepository = speakerRepository;
        _organizerRepository = organizerRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IEnumerable<EventViewDto>> GetAllEventsAsync()
    {
        var events = await _eventRepository.GetAllEventsAsync();
        
        if (!events.Any())
            throw new EventsNotFoundException("No events found");
        
        return _mapper.Map<IEnumerable<EventViewDto>>(events);
    }

    public async Task<EventViewDto?> GetEventByIdAsync(Guid id)
    {
        var eventById = await _eventRepository.GetEventByIdAsync(id) ??
                        throw new KeyNotFoundException("Event with this id does not exist");
        return _mapper.Map<EventViewDto>(eventById);
    }

    public async Task<CreatedEventDto> CreateEventAsync(CreateEventDto newCreateEventDto)
    {
        var speaker = await _speakerRepository.GetSpeakerByNameAsync(newCreateEventDto.SpeakerName) ??
                      await _speakerRepository.CreateSpeakerAsync(new Speaker
                      {
                          Name = newCreateEventDto.SpeakerName
                      });

        var organizerId =
            new Guid(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value!);
        var organizer = await _organizerRepository.GetOrganizerByIdAsync(organizerId) ??
                        throw new KeyNotFoundException("Organizer not found");

        var newEvent = _mapper.Map<Event>(newCreateEventDto);
        newEvent.Speaker = speaker;
        newEvent.Organizer = organizer;

        return _mapper.Map<CreatedEventDto>(await _eventRepository.CreateEventAsync(newEvent));
    }

    public async Task<UpdatedEventDto> UpdateEventAsync(Guid id, UpdateEventDto updateEventDto)
    {
        var eventToUpdate = await _eventRepository.GetEventByIdAsync(id) ??
                            throw new KeyNotFoundException($"Event with id {id} not found");
        var currentOrganizerId =
            new Guid(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value!);

        if (eventToUpdate.OrganizerId != currentOrganizerId)
            throw new ForbiddenEventException("You are not allowed to update this event");

        var updatedEvent = _mapper.Map<Event>(updateEventDto);

        var updatedSpeaker = await _speakerRepository.GetSpeakerByNameAsync(updateEventDto.SpeakerName) ??
                             await _speakerRepository.CreateSpeakerAsync(new Speaker
                             {
                                 Name = updateEventDto.SpeakerName
                             });

        updatedEvent.Id = id;
        updatedEvent.SpeakerId = updatedSpeaker.Id;
        updatedEvent.OrganizerId = eventToUpdate.OrganizerId;

        return _mapper.Map<UpdatedEventDto>(await _eventRepository.UpdateEventAsync(eventToUpdate, updatedEvent));
    }

    public async Task<DeletedEventDto> DeleteEventAsync(Guid id)
    {
        var eventToDelete = await _eventRepository.GetEventByIdAsync(id) ??
                            throw new ArgumentException($"Event with id {id} not found");

        var currentOrganizerId =
            new Guid(_httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value!);

        if (eventToDelete.OrganizerId != currentOrganizerId)
            throw new BadHttpRequestException("You are not allowed to delete this event");

        return _mapper.Map<DeletedEventDto>(await _eventRepository.DeleteEventAsync(eventToDelete));
    }
}
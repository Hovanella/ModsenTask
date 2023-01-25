using AutoMapper;
using ModsenTask.Dtos;
using ModsenTask.Models;

namespace ModsenTask.Mappings;

public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventViewDto>().ForMember(e => e.OrganizerName, opt => opt.MapFrom(e => e.Organizer.Name))
            .ForMember(e => e.SpeakerName, opt => opt.MapFrom(e => e.Speaker.Name));

        CreateMap<Event, CreatedEventDto>().ForMember(e => e.OrganizerName, opt => opt.MapFrom(e => e.Organizer.Name))
            .ForMember(e => e.SpeakerName, opt => opt.MapFrom(e => e.Speaker.Name));

        CreateMap<Event, UpdatedEventDto>().ForMember(e => e.OrganizerName, opt => opt.MapFrom(e => e.Organizer.Name))
            .ForMember(e => e.SpeakerName, opt => opt.MapFrom(e => e.Speaker.Name));

        CreateMap<Event, DeletedEventDto>().ForMember(e => e.OrganizerName, opt => opt.MapFrom(e => e.Organizer.Name))
            .ForMember(e => e.SpeakerName, opt => opt.MapFrom(e => e.Speaker.Name));

        CreateMap<RegisterOrganizerDto, Organizer>().ForMember(e => e.Password, opt => opt.Ignore());
        CreateMap<Organizer, RegisteredOrganizerDto>().ForMember(e => e.Password, opt => opt.Ignore());

        CreateMap<CreateEventDto, Event>();

        CreateMap<UpdateEventDto, Event>();
    }
}
using AutoMapper;
using ModsenTask.Dtos;
using ModsenTask.Models;

namespace ModsenTask.Mappings;

public class OrganizerProfile : Profile
{
    public OrganizerProfile()
    {
        CreateMap<RegisterOrganizerDto, Organizer>().ForMember(e => e.Password, opt => opt.Ignore());
        CreateMap<Organizer, RegisteredOrganizerDto>().ForMember(e => e.Password, opt => opt.Ignore());
    }
    
}
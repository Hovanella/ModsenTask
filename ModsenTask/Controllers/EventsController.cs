using Microsoft.AspNetCore.Mvc;
using ModsenTask.Dtos;
using ModsenTask.Services.Interfaces;

namespace ModsenTask.Controllers;

[ApiController]
[Route("[controller]")]
public class EventsController : Controller
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEventsAsync()
    {
        var events = await _eventService.GetAllEventsAsync();
        return !events.Any() ? NotFound() : Ok(events);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventByIdAsync(Guid id)
    {
        var eventById = await _eventService.GetEventByIdAsync(id);
        return eventById == null ? NotFound() : Ok(eventById);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventDto createEventDto)
    {
        var createdEvent = await _eventService.CreateEventAsync(createEventDto);
        return Created(new Uri($"{Request.Path}/{createdEvent.Id}",UriKind.Relative), createdEvent);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEventAsync(Guid id, [FromBody] UpdateEventDto updateEventDto)
    {
        return Ok(await _eventService.UpdateEventAsync(id, updateEventDto));
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEventAsync(Guid id)
    {
        return Ok(await _eventService.DeleteEventAsync(id));
    }
}
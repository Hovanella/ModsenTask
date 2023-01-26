using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModsenTask.Dtos;
using ModsenTask.Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace ModsenTask.Controllers;

[ApiController]
[Route("[controller]")]
[SwaggerTag("This controller is used to manage the events")]
public class EventsController : Controller
{
    private readonly IEventService _eventService;

    public EventsController(IEventService eventService)
    {
        _eventService = eventService;
    }

    [HttpGet]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Returns a list of all events.", Description = "Returns a list of all events.")]
    [SwaggerResponse(200, Type = typeof(IEnumerable<EventViewDto>),
        Description = "200 OK: Returns a list of all events.")]
    [SwaggerResponse(404, Description = "404 Not Found: No events were found in the database.")]
    public async Task<IActionResult> GetAllEventsAsync()
    {
        var events = await _eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    [SwaggerOperation(Summary = "Returns an event with the specified id.",
        Description = "Returns an event with the specified id")]
    [SwaggerResponse(200, Type = typeof(EventViewDto), Description = "200 OK: Event with the specified id was found.")]
    [SwaggerResponse(404, Description = "404 Not Found: No event with the specified ID was found.")]
    public async Task<IActionResult> GetEventByIdAsync(Guid id)
    {
        var eventById = await _eventService.GetEventByIdAsync(id);
        return Ok(eventById);
    }

    [HttpPost]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(Summary = "Creates a new event.", Description = "Creates a new event.")]
    [SwaggerResponse(201, Type = typeof(CreatedEventDto), Description = "201 Created: Event was created successfully.")]
    [SwaggerResponse(400, Description = "400 Bad Request: The request body is not valid.")]
    [SwaggerResponse(401, Description = "401 Unauthorized: Organizer is not authorized to create an event.")]
    public async Task<IActionResult> CreateEventAsync([FromBody] CreateEventDto createEventDto)
    {
        var createdEvent = await _eventService.CreateEventAsync(createEventDto);
        return Created(new Uri($"{Request.Path}/{createdEvent.Id}", UriKind.Relative), createdEvent);
    }

    [HttpPut("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [SwaggerOperation(Summary = "Updates an event with the specified id.",
        Description = "Updates an event with the specified id.")]
    [SwaggerResponse(200, Type = typeof(UpdatedEventDto), Description = "200 OK: Event was updated successfully.")]
    [SwaggerResponse(400, Description = "400 Bad Request: The request body is not valid.")]
    [SwaggerResponse(401, Description = "401 Unauthorized: Organizer is not authorized to update the event.")]
    [SwaggerResponse(403, Description = "403 Forbidden: Organizer is not authorized to update the event.")]
    [SwaggerResponse(404, Description = "404 Not Found: No event with the specified ID was found.")]
    public async Task<IActionResult> UpdateEventAsync(Guid id, [FromBody] UpdateEventDto updateEventDto)
    {
        return Ok(await _eventService.UpdateEventAsync(id, updateEventDto));
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Deletes an event with the specified id.",
        Description = "Deletes an event with the specified id.")]
    [SwaggerResponse(200, Type = typeof(DeletedEventDto), Description = "200 OK: Event was deleted successfully.")]
    [SwaggerResponse(401, Description = "401 Unauthorized: Organizer is not authorized to delete the event.")]
    [SwaggerResponse(403, Description = "403 Forbidden: Organizer is not authorized to delete the event.")]
    [SwaggerResponse(404, Description = "404 Not Found: No event with the specified ID was found.")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> DeleteEventAsync(Guid id)
    {
        return Ok(await _eventService.DeleteEventAsync(id));
    }
}
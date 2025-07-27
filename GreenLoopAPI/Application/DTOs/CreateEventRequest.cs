using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.DTOs;

public class CreateEventRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime StartDate { get; set; }
    public string Location { get; set; } = null!;
    public EventCategory Category { get; set; }
    
    
}
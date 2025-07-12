using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.DTOs;

public class CreateEventRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    
    public String Location { get; set; }
    
    public EventCategory Category { get; set; }
    
    public int OrganizerId { get; set; }
}
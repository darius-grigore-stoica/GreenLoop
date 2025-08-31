using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.DTOs;

public class CreateEventRequest
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public string Location { get; set; } = null!;
    public String Category { get; set; } = new EventCategory().ToString(); // TODO: fix the json string - event category mapping
    public int CreatorId { get; set; }
    
    
}
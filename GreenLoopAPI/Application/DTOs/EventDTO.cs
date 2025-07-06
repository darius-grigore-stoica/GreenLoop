using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.DTOs;

public class EventDTO
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public string Location { get; set; } = null!;
    public EventCategory Category { get; set; }

    public int CreatorId { get; set; }
    public UserDTO Creator { get; set; } = null!;
}
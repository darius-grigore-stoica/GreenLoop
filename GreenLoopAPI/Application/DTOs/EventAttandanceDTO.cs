using GreenLoopAPI.Core.Entities;

namespace GreenLoopAPI.Application.DTOs;

public class EventAttandanceDTO
{
    public int Id { get; set; }
    public Event Event { get; set; } = null!;
    public User User { get; set; } = null!;
}
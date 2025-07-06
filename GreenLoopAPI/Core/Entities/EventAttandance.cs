namespace GreenLoopAPI.Core.Entities;

public class EventAttandance
{
    public int Id { get; set; }
    public Event Event { get; set; } = null!;
    public User User { get; set; } = null!;
}
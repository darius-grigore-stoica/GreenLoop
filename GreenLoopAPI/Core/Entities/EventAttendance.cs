namespace GreenLoopAPI.Core.Entities;

public class EventAttendance
{
    public int Id { get; set; }
    public Event Event { get; set; } = null!;
    public User User { get; set; } = null!;

    public EventAttendance(Event e, User u)
    {
        Event = e;
        User = u;
    }
 }
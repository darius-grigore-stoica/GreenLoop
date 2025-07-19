namespace GreenLoopAPI.Core.Entities;

public class Event
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime DateTime { get; set; }
    public string Location { get; set; } = null!;
    public EventCategory Category { get; set; }
    public int CreatorId { get; set; }
    public User Creator { get; set; } = null!;

    public Event() { }
    public Event(string title, string description, DateTime dateTime, string location, EventCategory category,
        User creator)
    {
        Title = title;
        Description = description;
        DateTime = dateTime;
        Location = location;
        Category = category;
        Creator = creator;
    }
}
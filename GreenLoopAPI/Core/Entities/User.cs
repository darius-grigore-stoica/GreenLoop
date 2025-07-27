using System.ComponentModel.DataAnnotations.Schema;

namespace GreenLoopAPI.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Username { get; set; } = null!;
    
    public ICollection<Event> AttendedEvents { get; set; } = new List<Event>();

    public User(string email, string passwordHash, string username)
    {
        Email = email;
        PasswordHash = passwordHash;
        Username = username;
    }
}
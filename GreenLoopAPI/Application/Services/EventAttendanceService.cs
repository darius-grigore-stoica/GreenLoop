using GreenLoopAPI.Application.Interfaces;
using GreenLoopAPI.Core.Entities;
using GreenLoopAPI.Core.Interfaces;
using GreenLoopAPI.Infrastructure.Repositories;

namespace GreenLoopAPI.Application.Services;

public class EventAttendanceService(
    IEventRepository eventRepository,
    IUserRepository userRepository,
    IEventAttendanceRepository eventAttendanceRepository)
    : IEventAttandanceService
{
    private readonly IEventRepository _eventRepository = eventRepository;
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEventAttendanceRepository _eventAttendanceRepository = eventAttendanceRepository;

    public async Task<bool> AttendEventAsync(int eventId, int userId)
    {
        var e = await _eventRepository.GetByIdAsync(eventId);
        var u = await _userRepository.GetByIdAsync(userId);

        var attendance = new EventAttendance(e, u);

        await _eventAttendanceRepository.AddAsync(attendance);
        return true;
    }

    public async Task<IEnumerable<User>?> GetAttendeesForEventAsync(int eventId)
    {
        IEnumerable<EventAttendance> attendances = await _eventAttendanceRepository.GetAllAsync();
        List<User> attendeesList = new List<User>();
        foreach(EventAttendance a in attendances)
        {
            if (a.Event.Id == eventId)
            {
                attendeesList.Add(a.User);
            }
        }
        
        return attendeesList.Count > 0 ? attendeesList : null;
    }
}
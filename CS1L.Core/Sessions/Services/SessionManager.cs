using CS1L.Core.Sessions.Interfaces;
using CS1L.Core.Sessions.Models;
using Timer = System.Timers.Timer;

namespace CS1L.Core.Sessions.Services;


public class SessionManager : ISessionManager
{
    private readonly Dictionary<Guid, Session> _sessions = new();
    private readonly Dictionary<Guid, Timer> _timers = new();

    public Guid Create(long userId)
    {
        var session = new Session { Id = Guid.NewGuid(), UserId = userId };
        _sessions.Add(session.Id, session);
        CreateTimer(session);
        return session.Id;
    }

    public Session? GeById(Guid id)
    {
        _sessions.TryGetValue(id, out var session);
        if (session is not null) UpdateTimer(session);
        return session;
    }

    public Session? GetByUserId(long userId)
    {
        var session = _sessions.Values.FirstOrDefault(session => session.UserId == userId);
        if (session is not null) UpdateTimer(session);
        return session;
    }

    public void IsAlive(long userId)
    {
        var session = _sessions.Values.FirstOrDefault(session => session.UserId == userId);
        if (session is not null) UpdateTimer(session);
    }

    private void UpdateTimer(Session session)
    {
        _timers.TryGetValue(session.Id, out var timer);
        if (timer is null) throw new NullReferenceException("timer not found");
        timer.Stop();
        timer.Interval = session.Lifetime.TotalMilliseconds;
        timer.Start();
    }

    private void CreateTimer(Session session)
    {
        var timer = new Timer(session.Lifetime.TotalMilliseconds);
        timer.Elapsed += (_, _) =>
        {
            _sessions.Remove(session.Id);
            _timers.Remove(session.Id);
            timer.Dispose();
        };
        _timers.Add(session.Id, timer);
        timer.Start();
    }
}

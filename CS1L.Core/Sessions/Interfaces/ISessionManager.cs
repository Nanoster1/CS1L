using CS1L.Core.Sessions.Models;

namespace CS1L.Core.Sessions.Interfaces;

public interface ISessionManager
{
    Session? GetByUserId(long userId);
    Session? GetById(Guid sessionId);
    Guid Create(long userId);
}

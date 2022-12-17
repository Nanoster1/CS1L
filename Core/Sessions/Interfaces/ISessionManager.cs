using Core.Sessions.Models;

namespace Core.Sessions.Interfaces;

public interface ISessionManager
{
    Session? GetByUserId(long userId);
    Session? GeById(Guid sessionId);
    Guid Create(long userId);
}

using CS1L.Core.Sessions.Services;

namespace CS1L.Core.GameActions.Services;

public class GameActionsService
{
    private readonly SessionService _sessionService;

    public GameActionsService(SessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public void GiveAnswer(Guid hostSessionId, Guid playerSessionId, int questionId, int answerId)
    {
        var playerSession = _sessionService.GetPlayerSession(hostSessionId, playerSessionId);
        if (playerSession is null) return;
        
    }
}

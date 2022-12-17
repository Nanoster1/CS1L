using CS1L.Core.Sessions.Services;
using CS1L.Shared.Models.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace CS1L.Server.Hubs;

public class SessionHub : Hub
{
    private readonly SessionService _sessionService;

    public SessionHub(SessionService sessionService)
    {
        _sessionService = sessionService;
    }

    public async Task Create(long vkId, int testId)
    {
        var session = await _sessionService.CreateHostSessionAsync(vkId, testId);
        await Groups.AddToGroupAsync(Context.ConnectionId, session.Id.ToString());
        await Clients.Caller.SendAsync("Created", session);
    }

    public async Task Connect(GameConnectDto dto)
    {
        var session = _sessionService.Connect(dto);
        await Groups.AddToGroupAsync(Context.ConnectionId, session.Id.ToString());
        await Clients.Caller.SendAsync("Connected", session);
        await Clients.OthersInGroup(session.HostId.ToString()).SendAsync("ConnectedNewPlayer", session);
    }
    
    public async Task StartGame(Guid sessionId)
    {

    }
}

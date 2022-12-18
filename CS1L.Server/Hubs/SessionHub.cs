using CS1L.Core.Sessions.Services;
using CS1L.Shared.Models.DTOs;
using CS1L.Shared.Models.Tests;
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
        await Groups.AddToGroupAsync(Context.ConnectionId, session.HostId.ToString());
        await Clients.Caller.SendAsync("Connected", session);
        await Clients.OthersInGroup(session.HostId.ToString()).SendAsync("ConnectedNewPlayer", session);
    }

    public async Task StartGame(Guid sessionId)
    {
        _sessionService.StartGame(sessionId);
        await Clients.Group(sessionId.ToString()).SendAsync("GameStarted");
    }

    public async Task GetQuestion(Guid sessionId, Question question)
    {
        await Clients.OthersInGroup(sessionId.ToString()).SendAsync("Question", question);
    }

    public async Task Answer(Guid sessionId, Guid playerSessionId,int scores)
    {
        await Clients.Group(sessionId.ToString()).SendAsync("UserGotAnswer", playerSessionId,scores);
    }

    public async Task Finish(Guid sessionId)
    {
        await Clients.Group(sessionId.ToString()).SendAsync("GameEnded");
    }
    public async Task FullFinish(Guid sessionId)
    {
        await Clients.Group(sessionId.ToString()).SendAsync("GameFullEnded");
    }
}

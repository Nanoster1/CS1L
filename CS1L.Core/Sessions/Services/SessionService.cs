// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Concurrent;
using CS1L.Core.Sessions.Models;
using CS1L.Core.Tests.Interfaces;
using CS1L.Shared.Models.DTOs;

namespace CS1L.Core.Sessions.Services;

public class SessionService
{
    private readonly ITestRepository _testRepository;
    private readonly SessionStorage _storage;

    public SessionService(ITestRepository testRepository, SessionStorage storage)
    {
        _testRepository = testRepository;
        _storage = storage;
    }

    public HostSession? GetHostSession(Guid id) => _storage.TryGetValue(id, out var session) ? session : null;

    public async Task<HostSession> CreateHostSessionAsync(long vkId, int testId)
    {
        var test = await _testRepository.GetAsync(testId);
        if (test is null) throw new ArgumentException("Test not found", nameof(testId));

        var session = new HostSession()
        {
            Id = Guid.NewGuid(),
            VkId = vkId,
            Test = test
        };

        var addResult = _storage.TryAdd(session.Id, session);
        if (!addResult) throw new InvalidOperationException("Session already exists");

        return session;
    }

    public bool? CheckHostSession(Guid sessionId, int version)
    {
        var session = GetHostSession(sessionId);
        return session?.Version == version;
    }

    public bool? CheckPlayerSession(Guid hostSessionId, Guid playerSessionId, int version)
    {
        var session = GetPlayer(hostSessionId, playerSessionId);
        return session?.Version == version;
    }

    public PlayerSession? GetPlayer(Guid hostId, Guid playerId)
    {
        var session = GetHostSession(hostId);
        if (session is null) throw new ArgumentException("Session not found", nameof(hostId));
        return session.Players.GetValueOrDefault(playerId);
    }

    public PlayerSession Connect(GameConnectDto dto)
    {
        PlayerSession player = new()
        {
            Id = Guid.NewGuid(),
            HostId = dto.HostId,
            Nickname = dto.NickName,
            VkId = dto.VkId
        };
        var hostSession = GetHostSession(dto.HostId);
        if (hostSession is null) throw new ArgumentException("Host session not found", nameof(dto));
        hostSession.Players.TryAdd(player.Id, player);
        return player;
    }
}

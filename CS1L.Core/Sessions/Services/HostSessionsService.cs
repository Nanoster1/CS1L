// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Models;
using CS1L.Shared.Models;

namespace CS1L.Core.Sessions.Services;

public class HostSessionsService
{
    private readonly Dictionary<Guid, HostSession> _storage = new();

    public HostSession? GetSession(Guid id) => _storage.GetValueOrDefault(id);
    public bool RemoveSession(Guid id) => _storage.Remove(id);

    public HostSession CreateSession(long vkId, Test test)
    {
        HostSession session = new()
        {
            Id = Guid.NewGuid(),
            VkId = vkId,
            Test = test,
        };
        _storage.Add(session.Id, session);
        return session;
    }

    public bool? Check(Guid sessionId, int version)
    {
        var session = GetSession(sessionId);
        if (session is null) return null;
        return session.Version == version;
    }
}

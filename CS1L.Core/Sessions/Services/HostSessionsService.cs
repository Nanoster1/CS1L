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
    public HostSession CreateSession(ulong vkId, Test test)
    {
        HostSession session = new()
        {
            Id = Guid.NewGuid(),
            Test = test,
            VkId = vkId,
        };
        _storage.Add(session.Id, session);
        return session;
    }
    public bool RemoveSession(Guid id) => _storage.Remove(id);
}

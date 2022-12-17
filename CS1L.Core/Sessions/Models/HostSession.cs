// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Interfaces;
using CS1L.Shared.Models;

namespace CS1L.Core.Sessions.Models;

public class HostSession : ISessionIdentity
{
    private readonly Dictionary<Guid, PlayerSession> _players = new();
    public Guid Id { get; set; }
    public ulong VkId { get; set; }
    public required Test Test { get; init; }

    public PlayerSession? GetPlayer(Guid id) => _players.GetValueOrDefault(id);
    public PlayerSession CreatePlayer(ulong vkId, string nickname)
    {
        PlayerSession player = new()
        {
            Id = Guid.NewGuid(),
            HostId = this.Id,
            Nickname = nickname,
            VkId = vkId,
        };
        _players[player.Id] = player;
        return player;
    }
    public bool RemovePlayer(Guid id) => _players.Remove(id);
}

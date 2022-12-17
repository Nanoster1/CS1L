// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Interfaces;

namespace CS1L.Core.Sessions.Models;

public class PlayerSession : ISessionIdentity
{
    public required Guid Id { get; init; }
    public required Guid HostId { get; init; }
    public required ulong VkId { get; init; }
    public required string Nickname { get; init; }
    public required int Score { get; set; }
    public PlayerSessionStatus Status { get; set; }
    public int? AnswersCount { get; set; }
}

public enum PlayerSessionStatus
{
    Lobby,
    Answering,
    Finish
}

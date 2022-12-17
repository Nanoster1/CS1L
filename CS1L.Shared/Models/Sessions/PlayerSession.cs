// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CS1L.Shared.Models.Sessions;

public class PlayerSession : SessionIdentity
{
    public override Guid Id { get; set; }
    public override long VkId { get; set; }
    public Guid HostId { get; set; }
    public override int Version { get; set; } = 1;
    public string Nickname { get; set; } = string.Empty;
    public int Score { get; set; } = 0;
    public PlayerSessionStatus Status { get; set; }
    public int? AnswersCount { get; set; }
}

public enum PlayerSessionStatus
{
    Lobby,
    Answering,
    Finish
}

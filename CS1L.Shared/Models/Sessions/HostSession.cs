// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Concurrent;
using CS1L.Shared.Models.Tests;

namespace CS1L.Shared.Models.Sessions;

public class HostSession : SessionIdentity
{
    public ConcurrentDictionary<Guid, PlayerSession> Players = new();
    public Guid Id { get; set; }
    public long VkId { get; set; }
    public int Version { get; set; } = 1;
    public Test Test { get; init; } = null!;
}

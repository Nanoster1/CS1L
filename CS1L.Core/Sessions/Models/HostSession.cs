// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using CS1L.Core.Sessions.Interfaces;

namespace CS1L.Core.Sessions.Models;

public class HostSession : ISessionIdentity
{
    public Guid Id { get; set; }
    public ulong VkId { get; set; }
}

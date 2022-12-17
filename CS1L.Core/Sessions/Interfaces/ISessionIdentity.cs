﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CS1L.Core.Sessions.Interfaces;

public interface ISessionIdentity
{
    public Guid Id { get; set; }
    public ulong VkId { get; set; }
}
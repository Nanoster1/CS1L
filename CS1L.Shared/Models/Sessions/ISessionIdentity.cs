// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CS1L.Shared.Models.Sessions;

public interface ISessionIdentity
{
    Guid Id { get; }
    long VkId { get; }
}

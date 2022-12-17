// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace CS1L.Shared.Models.DTOs;

public record GameConnectDTO(
    Guid HostId,
    long VkId,
    string NickName);

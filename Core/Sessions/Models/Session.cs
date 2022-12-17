using System.Security.Cryptography.X509Certificates;
using System;

namespace Core.Sessions.Models;

public class Session
{
    public required Guid Id { get; init; }
    public required long UserId { get; init; }
    public TimeSpan Lifetime { get; init; } = TimeSpan.FromMinutes(15);
}

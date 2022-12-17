using System.Security.Cryptography.X509Certificates;
using CS1L.Core.Sessions.Interfaces;
using CS1L.Shared.Models;

namespace CS1L.Core.Sessions.Models;

public class PlayerSession : ISessionIdentity
{
    public required Guid Id { get; init; }
    public required ulong VkId { get; init; }
    public PlayerSessionStatus Status { get; set; }
    public int? AnswersCount { get; set; }
}

public enum PlayerSessionStatus
{
    Lobby,
    Answering,
    Finish
}

using System.Security.Cryptography.X509Certificates;
using CS1L.Shared.Models;

namespace CS1L.Core.Sessions.Models;

public class PlayerSession
{
    public Guid Id { get; set; }
    public PlayerSessionStatus Status { get; set; }
    public int? AnswersCount { get; set; }
}

public enum PlayerSessionStatus
{
    Lobby,
    Answering,
    Finish
}

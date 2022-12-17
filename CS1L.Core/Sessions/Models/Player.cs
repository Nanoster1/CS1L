using CS1L.Core.Sessions.Interfaces;

namespace CS1L.Core.Sessions.Models;

public class Player
{
    public required string Nickname { get; init; }
    public required int Score { get; init; }
}

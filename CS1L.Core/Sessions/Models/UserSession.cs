using System.Security.Cryptography.X509Certificates;
namespace CS1L.Core.Sessions.Models;

public class UserSession
{
    public Guid Id { get; set; }
    public User User { get; set; }

}

public enum UserSessionState
{
}

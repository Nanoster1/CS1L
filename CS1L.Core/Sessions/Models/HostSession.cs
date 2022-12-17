using CS1L.Core.Interfaces;

namespace CS1L.Core.Sessions.Models;

public class HostSession : ISessionIdentity
{
    public Guid Id { get; set; }
    public ulong VkId { get; set; }
}

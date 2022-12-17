using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics.CodeAnalysis;
using CS1L.Shared.Models.Sessions;

namespace CS1L.Core.Sessions.Services;

public class SessionStorage : IDictionary<Guid, HostSession>
{
    private readonly IDictionary<Guid, HostSession> _sessions = new ConcurrentDictionary<Guid, HostSession>();

    public HostSession this[Guid key] { get => _sessions[key]; set => _sessions[key] = value; }

    public ICollection<Guid> Keys => _sessions.Keys;

    public ICollection<HostSession> Values => _sessions.Values;

    public int Count => _sessions.Count;

    public bool IsReadOnly => _sessions.IsReadOnly;

    public void Add(Guid key, HostSession value)
    {
        _sessions.Add(key, value);
    }

    public void Add(KeyValuePair<Guid, HostSession> item)
    {
        _sessions.Add(item);
    }

    public void Clear()
    {
        _sessions.Clear();
    }

    public bool Contains(KeyValuePair<Guid, HostSession> item)
    {
        return _sessions.Contains(item);
    }

    public bool ContainsKey(Guid key)
    {
        return _sessions.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<Guid, HostSession>[] array, int arrayIndex)
    {
        _sessions.CopyTo(array, arrayIndex);
    }

    public IEnumerator<KeyValuePair<Guid, HostSession>> GetEnumerator()
    {
        return _sessions.GetEnumerator();
    }

    public bool Remove(Guid key)
    {
        return _sessions.Remove(key);
    }

    public bool Remove(KeyValuePair<Guid, HostSession> item)
    {
        return _sessions.Remove(item);
    }

    public bool TryGetValue(Guid key, [MaybeNullWhen(false)] out HostSession value)
    {
        return _sessions.TryGetValue(key, out value);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)_sessions).GetEnumerator();
    }
}

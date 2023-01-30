namespace RSS.Api.Session;

public static class SessionHandler
{
    private static Dictionary<Guid, string> _sessions = new Dictionary<Guid, string>();

    public static void AddSession(Guid userId, string token)
    {
        if (_sessions.TryGetValue(userId, out var session))
        {
            _sessions[userId] = token;
        }
        else
        {
            _sessions.Add(userId, token);
        }
    }

    public static Guid? GetUserIdByToken(string token)
    {
        var hasActiveSession = _sessions.Values.Any(t => t == token);
        if (hasActiveSession)
        {
            var pair = _sessions.FirstOrDefault(i => i.Value == token);
            return pair.Key;
        }

        return null;
    }
}

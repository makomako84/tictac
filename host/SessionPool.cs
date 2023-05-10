﻿using MakoSystems.TicTac.Core;
namespace MakoSystems.TicTac.Host;

public class SessionPool : ISessionPool
{
    private List<Session> _sessions;

    public SessionPool() 
    {
        _sessions = new List<Session>();
    }

    public Session GetExistingSession(Guid id)
    {
        throw new NotImplementedException();
    }

    public Session GetNewSession()
    {
        var session = new Session();
        _sessions.Add(session);
        return session;
    }

    public void TerminateSession(Guid id)
    {
        throw new NotImplementedException();
    }
}

public interface ISessionPool
{
    public Session GetNewSession();
    public Session GetExistingSession(Guid id);
    public void TerminateSession(Guid id);
}

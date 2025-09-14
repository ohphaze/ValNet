using System.Text.Json;
using RestSharp;
using ValNet.Objects.Local;

namespace ValNet.Requests;

public class Presence : RequestBase
{
    public Presence(RiotUser pUser) : base(pUser)
    {
        _user = pUser;
    }

    public async Task<ChatV4PresenceObj?> GetPresences()
    {
        // Requires lockfile to be present and SocketClient configured with TLS bypass
        var resp = await WebsocketRequest("/chat/v4/presences", Method.Get);
        if (!resp.isSucc || string.IsNullOrEmpty(resp.content?.ToString()))
            return null;
        try
        {
            return JsonSerializer.Deserialize<ChatV4PresenceObj>(resp.content.ToString());
        }
        catch
        {
            return null;
        }
    }
}


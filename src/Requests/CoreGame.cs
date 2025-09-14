using System.Text.Json;
using RestSharp;
using ValNet.Objects.Coregame;

namespace ValNet.Requests;

public class CoreGame : RequestBase
{
    public CoreGame(RiotUser pUser) : base(pUser)
    {
        _user = pUser;
    }

    public async Task<CoregamePlayer?> FetchPlayer()
    {
        var endpoint = $"/core-game/v1/players/{_user.UserData?.sub}";
        var resp = await RiotGlzRequest(endpoint, Method.Get);
        if (!resp.isSucc || string.IsNullOrEmpty(resp.content?.ToString()))
            return null;
        try
        {
            return JsonSerializer.Deserialize<CoregamePlayer>(resp.content.ToString());
        }
        catch
        {
            return null;
        }
    }

    public async Task<CoregameMatch?> FetchMatch(string matchId)
    {
        var endpoint = $"/core-game/v1/matches/{matchId}";
        var resp = await RiotGlzRequest(endpoint, Method.Get);
        if (!resp.isSucc || string.IsNullOrEmpty(resp.content?.ToString()))
            return null;
        try
        {
            return JsonSerializer.Deserialize<CoregameMatch>(resp.content.ToString());
        }
        catch
        {
            return null;
        }
    }
}


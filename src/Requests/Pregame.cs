namespace ValNet.Requests;

using System.Text.Json;
using RestSharp;
using ValNet.Objects.Pregame;

public class Pregame : RequestBase
{
    public Pregame(RiotUser pUser) : base(pUser)
    {
        _user = pUser;
    }

    public class PregamePlayer
    {
        public string MatchID { get; set; } = string.Empty;
    }

    public async Task<PregamePlayer?> GetPlayer()
    {
        var endpoint = $"/pregame/v1/players/{_user.UserData?.sub}";
        var resp = await RiotGlzRequest(endpoint, Method.Get);
        if (!resp.isSucc || string.IsNullOrEmpty(resp.content?.ToString()))
            return null;
        try
        {
            return JsonSerializer.Deserialize<PregamePlayer>(resp.content.ToString());
        }
        catch
        {
            return null;
        }
    }

    public async Task<PregameMatch?> GetMatch(string matchId)
    {
        var endpoint = $"/pregame/v1/matches/{matchId}";
        var resp = await RiotGlzRequest(endpoint, Method.Get);
        if (!resp.isSucc || string.IsNullOrEmpty(resp.content?.ToString()))
            return null;
        try
        {
            return JsonSerializer.Deserialize<PregameMatch>(resp.content.ToString());
        }
        catch
        {
            return null;
        }
    }
}

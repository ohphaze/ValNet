using System.Text.Json;
using RestSharp;
using ValNet.Objects.DisplayNameService;

namespace ValNet.Requests;

public class DisplayNameService : RequestBase
{
    public DisplayNameService(RiotUser pUser) : base(pUser)
    {
        _user = pUser;
    }

    public async Task<List<NameServicePlayerV2>> FetchPlayersV2(params string[] puuids)
    {
        var url = $"{_user._riotUrl.pdURL}/name-service/v2/players";
        var req = new RestRequest(url, Method.Put);
        req.AddJsonBody(puuids);
        var resp = await _user.UserClient.ExecuteAsync(req);
        if (!resp.IsSuccessful || string.IsNullOrEmpty(resp.Content))
            return new List<NameServicePlayerV2>();
        try
        {
            return JsonSerializer.Deserialize<List<NameServicePlayerV2>>(resp.Content) ?? new List<NameServicePlayerV2>();
        }
        catch
        {
            return new List<NameServicePlayerV2>();
        }
    }
}


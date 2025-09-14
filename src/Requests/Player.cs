using System.Text.Json;
using RestSharp;
using ValNet.Objects.Player;

namespace ValNet.Requests;

public class Player : RequestBase
{
    public Player(RiotUser pUser) : base(pUser)
    {
        _user = pUser;
    }


    /// <summary>
    /// Get Player's MMR / Stats
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<PlayerMMRObj> GetPlayerMmr()
    {
        var resp = await RiotPdRequest($"/mmr/v1/players/{_user.UserData.sub}", Method.Get);

        if (!resp.isSucc)
            throw new ValNet.Objects.Exceptions.RequestException("Failed to get Player MMR", (System.Net.HttpStatusCode)resp.StatusCode, resp.content?.ToString() ?? string.Empty);

        return JsonSerializer.Deserialize<PlayerMMRObj>(resp.content.ToString());
    }

    /// <summary>
    /// Get Player Competitive Updates, up to 15 matches.
    /// </summary>
    /// <returns>CompetitiveUpdateObj</returns>
    /// <exception cref="Exception"></exception>
    public async Task<CompetitiveUpdateObj?> GetCompetitiveUpdates()
    {
        var resp = await RiotPdRequest(
            $"/mmr/v1/players/{_user.UserData.sub}/competitiveupdates?startIndex=0&endIndex=15&queue=competitive",
            Method.Get);

        if (!resp.isSucc)
            throw new ValNet.Objects.Exceptions.RequestException("Failed to get Competitive Updates", (System.Net.HttpStatusCode)resp.StatusCode, resp.content?.ToString() ?? string.Empty);

        return JsonSerializer.Deserialize<CompetitiveUpdateObj>(resp.content.ToString());
    }

    /// <summary>
    /// Get Player's Match History up to 15 matches.
    /// </summary>
    /// <returns>MatchHistoryObj With Data</returns>
    /// <exception cref="Exception"></exception>
    public async Task<MatchHistoryObj?> GetPlayerMatchHistory()
    {
        var resp = await RiotPdRequest($"/match-history/v1/history/{_user.UserData.sub}", Method.Get);
        
        if (!resp.isSucc)
            throw new ValNet.Objects.Exceptions.RequestException("Failed to get Match History", (System.Net.HttpStatusCode)resp.StatusCode, resp.content?.ToString() ?? string.Empty);

        return JsonSerializer.Deserialize<MatchHistoryObj>(resp.content.ToString());
    }

    /// <summary>
    /// Get Player's Match History
    /// </summary>
    /// <param name="start">Starting Index for matches to look for</param>
    /// <param name="end">Ending Index for matches to look for</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<MatchHistoryObj> GetPlayerMatchHistory(int start, int end)
    {
        var resp = await RiotPdRequest(
            $"/match-history/v1/history/{_user.UserData.sub}?startIndex={start}&endIndex={end}", Method.Get);

        if (!resp.isSucc)
            throw new ValNet.Objects.Exceptions.RequestException("Failed to get Match History", (System.Net.HttpStatusCode)resp.StatusCode, resp.content?.ToString() ?? string.Empty);

        return JsonSerializer.Deserialize<MatchHistoryObj>(resp.content.ToString());
    }

    /// <summary>
    /// Gets Player's History from the ID Provided
    /// </summary>
    /// <param name="puuid">Player Id To Look for</param>
    /// <param name="region">Region of Player Id</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    
    /*public async Task<MatchHistoryObj> GetPlayerMatchHistory(string puuid, string region)
    {
        if (string.IsNullOrEmpty(puuid))
            throw new Exception("Player id is empty/null");

        var regionUrl = await _user.Authentication.GetRegionPdUrl(region);
        
        if(region == null)
            throw new Exception("Player Region is not valid for request.");
        
        var resp = await CustomRequest("{regionUrl}/match-history/v1/history/{puuid}", Method.Get);

        if (!resp.isSucc)
            throw new Exception("Failed to get Other Players Match History");

        return JsonSerializer.Deserialize<MatchHistoryObj>(resp.content.ToString());
    }*/

    /// <summary>
    /// Gets Player Progression (Account Level)
    /// </summary>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task<PlayerProgressionObj> GetPlayerProgression()
    {
        var resp = await RiotPdRequest($"/account-xp/v1/players/{_user.UserData.sub}", Method.Get);
        
        if (!resp.isSucc)
            throw new ValNet.Objects.Exceptions.RequestException("Failed to get User's Account Progression", (System.Net.HttpStatusCode)resp.StatusCode, resp.content?.ToString() ?? string.Empty);

        return JsonSerializer.Deserialize<PlayerProgressionObj>(resp.content.ToString());
    }

    // Overload used by Assist to fetch another user's MMR
    public async Task<ValNet.Objects.Player.PlayerMMR?> GetPlayerMmr(string puuid)
    {
        var resp = await RiotPdRequest($"/mmr/v1/players/{puuid}", Method.Get);

        if (!resp.isSucc)
            throw new Exception("Failed to get Player MMR");

        return JsonSerializer.Deserialize<ValNet.Objects.Player.PlayerMMR>(resp.content.ToString());
    }

    // Compat: match details endpoint used by Assist
    public async Task<MatchDetailsObj?> GetMatchDetails(string matchId)
    {
        if (string.IsNullOrWhiteSpace(matchId))
            throw new ArgumentException("matchId is required", nameof(matchId));
        var resp = await RiotPdRequest($"/match-details/v1/matches/{matchId}", Method.Get);
        if (!resp.isSucc)
            throw new Exception("Failed to get match details");
        return JsonSerializer.Deserialize<MatchDetailsObj>(resp.content.ToString());
    }

}

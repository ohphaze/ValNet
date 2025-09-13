using System.Text.Json.Serialization;

namespace ValNet.Objects.Player;

public class PlayerMMR
{
    [JsonPropertyName("LatestCompetitiveUpdate")] public LatestCompetitiveUpdateObj LatestCompetitiveUpdate { get; set; } = new();
    [JsonPropertyName("QueueSkills")] public QueueSkillsObj QueueSkills { get; set; } = new();

    public class LatestCompetitiveUpdateObj
    {
        [JsonPropertyName("SeasonID")] public string SeasonID { get; set; } = string.Empty;
        [JsonPropertyName("TierAfterUpdate")] public int TierAfterUpdate { get; set; }
    }

    public class QueueSkillsObj
    {
        [JsonPropertyName("competitive")] public CompetitiveObj competitive { get; set; } = new();
    }

    public class CompetitiveObj
    {
        [JsonPropertyName("SeasonalInfoBySeasonID")] public Dictionary<string, SeasonalInfo> SeasonalInfoBySeasonID { get; set; } = new();
    }

    public class SeasonalInfo
    {
        [JsonPropertyName("CompetitiveTier")] public int CompetitiveTier { get; set; }
        [JsonPropertyName("RankedRating")] public int RankedRating { get; set; }
        [JsonPropertyName("LeaderboardRank")] public int? LeaderboardRank { get; set; }
        [JsonPropertyName("NumberOfWins")] public int NumberOfWins { get; set; }
    }
}


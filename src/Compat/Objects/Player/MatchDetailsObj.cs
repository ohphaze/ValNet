using System.Text.Json.Serialization;

namespace ValNet.Objects.Player;

public class MatchDetailsObj
{
    [JsonPropertyName("MatchInfo")] public MatchInfoObj MatchInformation { get; set; } = new();
    [JsonPropertyName("Players")] public List<PlayerObj> Players { get; set; } = new();
    [JsonPropertyName("Teams")] public List<TeamObj> Teams { get; set; } = new();

    public class MatchInfoObj
    {
        [JsonPropertyName("MatchID")] public string MatchId { get; set; } = string.Empty;
        [JsonPropertyName("GameStartMillis")] public long GameStartMillis { get; set; }
        [JsonPropertyName("GameLengthMillis")] public long GameLengthMillis { get; set; }
        [JsonPropertyName("GameMode")] public string GameMode { get; set; } = string.Empty;
        [JsonPropertyName("QueueID")] public string QueueID { get; set; } = string.Empty;
        [JsonPropertyName("IsCompleted")] public bool IsCompleted { get; set; }
        [JsonPropertyName("MapID")] public string MapId { get; set; } = string.Empty;
    }

    public class PlayerObj
    {
        [JsonPropertyName("Subject")] public string Subject { get; set; } = string.Empty;
        [JsonPropertyName("TeamID")] public string TeamId { get; set; } = string.Empty;
        [JsonPropertyName("GameName")] public string GameName { get; set; } = string.Empty;
        [JsonPropertyName("TagLine")] public string TagLine { get; set; } = string.Empty;
        [JsonPropertyName("CharacterID")] public string CharacterId { get; set; } = string.Empty;
        [JsonPropertyName("CompetitiveTier")] public int CompetitiveTier { get; set; }
        [JsonPropertyName("Stats")] public StatsObj Stats { get; set; } = new();
    }

    public class StatsObj
    {
        [JsonPropertyName("Kills")] public int Kills { get; set; }
        [JsonPropertyName("Assists")] public int Assists { get; set; }
        [JsonPropertyName("Deaths")] public int Deaths { get; set; }
        [JsonPropertyName("Score")] public int Score { get; set; }
    }

    public class TeamObj
    {
        [JsonPropertyName("TeamID")] public string TeamId { get; set; } = string.Empty;
        [JsonPropertyName("RoundsWon")] public int RoundsWon { get; set; }
        [JsonPropertyName("RoundsPlayed")] public int RoundsPlayed { get; set; }
        [JsonPropertyName("Won")] public bool Won { get; set; }
        [JsonPropertyName("Roster")] public RosterInfoObj? RosterInfo { get; set; }
    }

    public class RosterInfoObj
    {
        [JsonPropertyName("Name")] public string Name { get; set; } = string.Empty;
    }
}


using System.Text.Json.Serialization;

namespace ValNet.Objects.Pregame;

// Minimal compat model for apps expecting ValNet.Objects.Pregame.PregameMatch
public class PregameMatch
{
    [JsonPropertyName("ID")] public string ID { get; set; } = string.Empty;
    [JsonPropertyName("MatchID")] public string MatchID { get; set; } = string.Empty;
    [JsonPropertyName("MapID")] public string MapID { get; set; } = string.Empty;
    [JsonPropertyName("GamePodID")] public string GamePodID { get; set; } = string.Empty;
    [JsonPropertyName("PregameState")] public string PregameState { get; set; } = string.Empty;
    [JsonPropertyName("Mode")] public string Mode { get; set; } = string.Empty;
    [JsonPropertyName("QueueID")] public string QueueID { get; set; } = string.Empty;
    [JsonPropertyName("ProvisioningFlowID")] public string ProvisioningFlowID { get; set; } = string.Empty;

    [JsonPropertyName("Players")] public List<Player> Players { get; set; } = new();

    // Some endpoints return teams array with players nested
    [JsonPropertyName("Teams")] public Team[] Teams { get; set; } = Array.Empty<Team>();

    // Some apps expect AllyTeam with TeamID and Players subset
    [JsonPropertyName("AllyTeam")] public Team AllyTeam { get; set; } = new();

    public class Player
    {
        [JsonPropertyName("Subject")] public string Subject { get; set; } = string.Empty;
        [JsonPropertyName("TeamID")] public string TeamID { get; set; } = string.Empty;
        [JsonPropertyName("CharacterID")] public string CharacterID { get; set; } = string.Empty;
        [JsonPropertyName("CharacterSelectionState")] public string CharacterSelectionState { get; set; } = string.Empty;
        [JsonPropertyName("PlayerIdentity")] public Identity PlayerIdentity { get; set; } = new();

        public class Identity
        {
            [JsonPropertyName("AccountLevel")] public int AccountLevel { get; set; }
            [JsonPropertyName("Incognito")] public bool Incognito { get; set; }
        }
    }

    public class Team
    {
        [JsonPropertyName("TeamID")] public string TeamID { get; set; } = string.Empty;
        [JsonPropertyName("Players")] public Player[] Players { get; set; } = Array.Empty<Player>();
    }
}

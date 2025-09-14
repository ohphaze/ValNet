using System.Text.Json.Serialization;

namespace ValNet.Objects.Coregame;

// Minimal compat model for apps expecting ValNet.Objects.Coregame.CoregameMatch
public class CoregameMatch
{
    [JsonPropertyName("MatchID")] public string MatchID { get; set; } = string.Empty;
    [JsonPropertyName("MapID")] public string MapID { get; set; } = string.Empty;
    [JsonPropertyName("GamePodID")] public string GamePodID { get; set; } = string.Empty;
    [JsonPropertyName("ProvisioningFlow")] public string ProvisioningFlow { get; set; } = string.Empty;
    // Common fields used by Assist
    [JsonPropertyName("State")] public string State { get; set; } = string.Empty;
    [JsonPropertyName("ModeID")] public string ModeID { get; set; } = string.Empty;

    [JsonPropertyName("MatchData")] public MatchDataObj MatchData { get; set; } = new();
    [JsonPropertyName("Players")] public List<Player> Players { get; set; } = new();

    public class MatchDataObj
    {
        [JsonPropertyName("QueueID")] public string QueueID { get; set; } = string.Empty;
    }

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
}

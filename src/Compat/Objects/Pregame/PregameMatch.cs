using System.Text.Json.Serialization;

namespace ValNet.Objects.Pregame;

// Minimal compat model for apps expecting ValNet.Objects.Pregame.PregameMatch
public class PregameMatch
{
    [JsonPropertyName("ID")] public string ID { get; set; } = string.Empty;
    [JsonPropertyName("MatchID")] public string MatchID { get; set; } = string.Empty;
    [JsonPropertyName("MapID")] public string MapID { get; set; } = string.Empty;

    [JsonPropertyName("Players")] public List<Player> Players { get; set; } = new();

    public class Player
    {
        [JsonPropertyName("Subject")] public string Subject { get; set; } = string.Empty;
        [JsonPropertyName("TeamID")] public string TeamID { get; set; } = string.Empty;
        [JsonPropertyName("CharacterID")] public string CharacterID { get; set; } = string.Empty;
        [JsonPropertyName("CharacterSelectionState")] public string CharacterSelectionState { get; set; } = string.Empty;
    }
}


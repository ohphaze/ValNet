using System.Text.Json.Serialization;

namespace ValNet.Objects.Coregame;

public class CoregamePlayer
{
    [JsonPropertyName("MatchID")] public string MatchID { get; set; } = string.Empty;
}


using System.Text.Json.Serialization;

namespace ValNet.Objects.Local;

// Compat DTO matching usage in Assist: instance type with presences list
public class ChatV4PresenceObj
{
    [JsonPropertyName("presences")] public List<Presence> presences { get; set; } = new();

    public class Presence
    {
        [JsonPropertyName("puuid")] public string puuid { get; set; } = string.Empty;
        [JsonPropertyName("game_name")] public string game_name { get; set; } = string.Empty;
        [JsonPropertyName("game_tag")] public string game_tag { get; set; } = string.Empty;
        [JsonPropertyName("private")] public string Private { get; set; } = string.Empty;

        [JsonExtensionData] public Dictionary<string, object>? Extra { get; set; }
    }
}

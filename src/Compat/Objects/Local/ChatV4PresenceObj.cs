using System.Text.Json.Serialization;

namespace ValNet.Objects.Local;

// Minimal compat DTO for clients expecting ValNet.Objects.Local.ChatV4PresenceObj
public static class ChatV4PresenceObj
{
    public class Presence
    {
        [JsonPropertyName("puuid")] public string puuid { get; set; } = string.Empty;
        [JsonPropertyName("game_name")] public string game_name { get; set; } = string.Empty;
        [JsonPropertyName("game_tag")] public string game_tag { get; set; } = string.Empty;

        // Allow for forward-compat with extra fields often deserialized by apps.
        [JsonExtensionData] public Dictionary<string, object>? Extra { get; set; }
    }
}


using System.Text.Json.Serialization;

namespace ValNet.Objects.Parties;

public class ValorantPartyPlayer
{
    [JsonPropertyName("Subject")] public string Subject { get; set; } = string.Empty;
    [JsonPropertyName("AccountLevel")] public int AccountLevel { get; set; }
    [JsonPropertyName("PlayerCardID")] public string PlayerCardID { get; set; } = string.Empty;
}


using System.Text.Json.Serialization;

namespace ValNet.Objects.Parties;

public class ValorantPartyPlayer
{
    [JsonPropertyName("Subject")] public string Subject { get; set; } = string.Empty;
    [JsonPropertyName("AccountLevel")] public int AccountLevel { get; set; }
    [JsonPropertyName("PlayerCardID")] public string PlayerCardID { get; set; } = string.Empty;

    // Implicit conversion from FetchPartyObj.Member for compatibility
    public static implicit operator ValorantPartyPlayer(ValNet.Objects.Party.FetchPartyObj.Member m)
    {
        return new ValorantPartyPlayer
        {
            Subject = m.Subject,
            AccountLevel = m.PlayerIdentity?.AccountLevel ?? 0,
            PlayerCardID = m.PlayerIdentity?.PlayerCardID ?? string.Empty
        };
    }
}

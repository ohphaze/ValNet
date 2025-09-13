using System.Text.Json.Serialization;

namespace ValNet.Objects.Store;

// Minimal compat wallet for apps expecting ValNet.Objects.Store.ValWallet
public class ValWallet
{
    [JsonPropertyName("Balances")] public BalanceObj Balances { get; set; } = new();

    public class BalanceObj
    {
        [JsonPropertyName("ValorantPoints")] public int ValorantPoints { get; set; }
        [JsonPropertyName("RadianitePoints")] public int RadianitePoints { get; set; }
        [JsonPropertyName("KingdomCredits")] public int KingdomCredits { get; set; }
    }
}


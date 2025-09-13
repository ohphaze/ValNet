using System.Text.Json.Serialization;

namespace ValNet.Objects.Store;

// Minimal compat offers for apps expecting ValNet.Objects.Store.ValOffers
public class ValOffers
{
    [JsonPropertyName("Offers")] public List<Offer> Offers { get; set; } = new();

    public class Offer
    {
        [JsonPropertyName("OfferID")] public string OfferID { get; set; } = string.Empty;
        [JsonPropertyName("Cost")] public CostObj Cost { get; set; } = new();
    }

    public class CostObj
    {
        [JsonPropertyName("VP")] public int VP { get; set; }
    }
}


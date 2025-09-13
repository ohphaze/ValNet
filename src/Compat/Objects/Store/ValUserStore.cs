using System.Text.Json.Serialization;

namespace ValNet.Objects.Store;

// Minimal compat store for apps expecting ValNet.Objects.Store.ValUserStore
public class ValUserStore
{
    [JsonPropertyName("FeaturedBundle")] public FeaturedBundleObj FeaturedBundle { get; set; } = new();
    [JsonPropertyName("SkinsPanelLayout")] public SkinsPanelLayoutObj SkinsPanelLayout { get; set; } = new();

    public class FeaturedBundleObj
    {
        [JsonPropertyName("Bundles")] public List<BundleObj> Bundles { get; set; } = new();
    }

    public class BundleObj
    {
        [JsonPropertyName("DataAssetID")] public string DataAssetID { get; set; } = string.Empty;
        [JsonPropertyName("Items")] public List<BundleItemObj> Items { get; set; } = new();
    }

    public class BundleItemObj
    {
        [JsonPropertyName("DiscountedPrice")] public int DiscountedPrice { get; set; }
    }

    public class SkinsPanelLayoutObj
    {
        [JsonPropertyName("SingleItemOffersRemainingDurationInSeconds")] public int SingleItemOffersRemainingDurationInSeconds { get; set; }
        [JsonPropertyName("SingleItemOffers")] public List<string> SingleItemOffers { get; set; } = new();
    }
}


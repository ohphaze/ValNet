using System.Text.Json;
using RestSharp;
using ValNet.Objects.Store;

namespace ValNet.Requests;

public class Store : RequestBase
{
    public Store(RiotUser pUser) : base(pUser)
    {
        _user = pUser;
    }

    public PlayerStore PlayerStore { get; set; }

    public async Task<ValNet.Objects.Store.ValUserStore> GetPlayerStore()
    {
        var resp = await RiotPdRequest($"/store/v2/storefront/{_user.UserData.sub}", Method.Get);

        if (!resp.isSucc)
            throw new Exception("Failed to get Player Store");

        PlayerStore = JsonSerializer.Deserialize<PlayerStore>(resp.content.ToString());

        // Map to compat store shape
        var compat = new ValNet.Objects.Store.ValUserStore
        {
            FeaturedBundle = new ValNet.Objects.Store.ValUserStore.FeaturedBundleObj
            {
                Bundles = PlayerStore.FeaturedBundle?.Bundles?.Select(b => new ValNet.Objects.Store.ValUserStore.BundleObj
                {
                    DataAssetID = b.DataAssetID,
                    Items = b.Items?.Select(i => new ValNet.Objects.Store.ValUserStore.BundleItemObj
                    {
                        DiscountedPrice = i.DiscountedPrice
                    }).ToList() ?? new List<ValNet.Objects.Store.ValUserStore.BundleItemObj>()
                }).ToList() ?? new List<ValNet.Objects.Store.ValUserStore.BundleObj>()
            },
            SkinsPanelLayout = new ValNet.Objects.Store.ValUserStore.SkinsPanelLayoutObj
            {
                SingleItemOffers = PlayerStore.SkinsPanelLayout?.SingleItemOffers ?? new List<string>(),
                SingleItemOffersRemainingDurationInSeconds = PlayerStore.SkinsPanelLayout?.SingleItemOffersRemainingDurationInSeconds ?? 0
            },
            BonusStore = PlayerStore.BonusStore
        };

        return compat;
    }

    public async Task<ValNet.Objects.Store.ValOffers> GetStoreOffers()
    {
        var resp = await RiotPdRequest("/store/v1/offers/", Method.Get);

        if (!resp.isSucc)
            throw new Exception("Failed to get Store Offers");

        try
        {
            return JsonSerializer.Deserialize<ValNet.Objects.Store.ValOffers>(resp.content.ToString());
        }
        catch
        {
            return new ValNet.Objects.Store.ValOffers();
        }
    }

    public async Task<PlayerWallet> GetPlayerBalance()
    {
        var resp = await RiotPdRequest($"/store/v1/wallet/{_user.UserData.sub}", Method.Get);
        
        if (!resp.isSucc)
            throw new Exception("Failed to get Player Balance");

        
        return JsonSerializer.Deserialize<PlayerWallet>(resp.content.ToString());
    }

    // Compat: Wallet wrapper exposing ValWallet
    public async Task<ValNet.Objects.Store.ValWallet> GetPlayerWallet()
    {
        var w = await GetPlayerBalance();
        var vw = new ValNet.Objects.Store.ValWallet
        {
            Balances = new ValNet.Objects.Store.ValWallet.BalanceObj
            {
                ValorantPoints = w.Balances.VP,
                RadianitePoints = w.Balances.RP,
                KingdomCredits = 0
            }
        };
        return vw;
    }
}

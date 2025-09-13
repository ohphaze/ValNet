using System.Net;

namespace ValNet.Core.Authentication;

// Thin compat wrapper matching older API expected by some apps
public class ClientAuthentication
{
    private readonly ValNet.RiotUser _user;

    public ClientAuthentication(ValNet.RiotUser user)
    {
        _user = user;
    }

    public void SetCookies(Dictionary<string, Cookie> cookieContainer)
    {
        if (cookieContainer == null) return;
        foreach (var kv in cookieContainer)
        {
            var c = kv.Value;
            // Default to riotgames.com if domain missing
            var domain = string.IsNullOrWhiteSpace(c.Domain) ? ".riotgames.com" : c.Domain;
            var path = string.IsNullOrWhiteSpace(c.Path) ? "/" : c.Path;
            var cookie = new Cookie(c.Name, c.Value, path, domain)
            {
                Secure = c.Secure,
                HttpOnly = c.HttpOnly,
                Expires = c.Expires
            };
            _user.UserClient.CookieContainer.Add(cookie);
        }
    }

    // Some consumers used to call this method here
    public async Task ReAuthWithCookies()
    {
        // Prefer curl-based flow when available for parity with older behavior
        await _user.Authentication.AuthenticateWithCookiesCurl();
    }
}


namespace ValNet.Requests;

public partial class Authentication
{
    // Compat shim for older consumers calling usr.Authentication.ReAuthWithCookies()
    public async Task ReAuthWithCookies()
    {
        await AuthenticateWithCookiesCurl();
    }
}


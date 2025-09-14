namespace ValNet.Requests;

public partial class Authentication
{
    // Compat shim for older consumers calling usr.Authentication.ReAuthWithCookies()
    public async Task<ValNet.Objects.Authentication.AuthenticationResult> ReAuthWithCookies()
    {
        try
        {
            await AuthenticateWithCookies();
            return new ValNet.Objects.Authentication.AuthenticationResult { bIsAuthComplete = true };
        }
        catch
        {
            return await AuthenticateWithCookiesCurl();
        }
    }
}

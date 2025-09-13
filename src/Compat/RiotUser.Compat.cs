namespace ValNet;

public partial class RiotUser
{
    // Compat method expected by existing apps
    public ValNet.Core.Authentication.ClientAuthentication GetAuthClient()
        => new ValNet.Core.Authentication.ClientAuthentication(this);
}


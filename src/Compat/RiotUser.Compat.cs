namespace ValNet;

public partial class RiotUser
{
    // Compat method expected by existing apps
    public ValNet.Core.Authentication.ClientAuthentication GetAuthClient()
        => new ValNet.Core.Authentication.ClientAuthentication(this);

    // Builder/compat configuration fields
    internal bool PreferCurl { get; set; } = false;
    internal string? CurlPath { get; set; } = null;

    // Compat helper used by Assist
    public ValNet.Enums.RiotRegion GetRegion()
    {
        try
        {
            var name = UserRegion.ToString();
            return (ValNet.Enums.RiotRegion)Enum.Parse(typeof(ValNet.Enums.RiotRegion), name, true);
        }
        catch
        {
            return ValNet.Enums.RiotRegion.UNKNOWN;
        }
    }
}

using ValNet.Objects.Authentication;
using ValNet.Enums;

namespace ValNet;

// Builder compatible with Assist's usage pattern
public class RiotUserBuilder
{
    private RiotLogin? _login;
    private ValNet.Enums.RiotRegion? _region;
    private string? _curlPath;
    private RiotUserSettings _settings = new RiotUserSettings();

    public RiotUserBuilder WithCredentials(RiotLogin login)
    {
        _login = login;
        return this;
    }

    public RiotUserBuilder WithRegion(ValNet.Enums.RiotRegion region)
    {
        _region = region;
        return this;
    }

    public RiotUserBuilder WithCustomCurl(string curlPath)
    {
        _curlPath = curlPath;
        return this;
    }

    public RiotUserBuilder WithSettings(RiotUserSettings settings)
    {
        _settings = settings ?? new RiotUserSettings();
        return this;
    }

    public RiotUser Build()
    {
        RiotUser user;
        if (_login is not null)
        {
            var data = new RiotLoginData
            {
                username = _login.username,
                password = _login.password
            };
            if (_region.HasValue)
            {
                var r = (ValNet.Objects.RiotRegion)System.Enum.Parse(typeof(ValNet.Objects.RiotRegion), _region.Value.ToString(), true);
                user = new RiotUser(data, r);
            }
            else
            {
                user = new RiotUser(data);
            }
        }
        else
        {
            user = new RiotUser();
            if (_region.HasValue)
            {
                var r = (ValNet.Objects.RiotRegion)System.Enum.Parse(typeof(ValNet.Objects.RiotRegion), _region.Value.ToString(), true);
                user.UserRegion = r;
            }
        }

        user.PreferCurl = _settings.AuthenticationMethod == AuthenticationMethod.CURL;
        user.CurlPath = _curlPath;
        return user;
    }
}

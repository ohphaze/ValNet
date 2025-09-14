namespace ValNet.Objects.Authentication;

// Lightweight compat class expected by Assist; maps to RiotLoginData
public class RiotLogin
{
    public string? username { get; set; }
    public string? password { get; set; }
}


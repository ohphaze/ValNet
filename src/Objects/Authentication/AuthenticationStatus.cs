namespace ValNet.Objects.Authentication;

public class AuthenticationStatus
{
    public int ValNetCode { get; set; }

    public bool bIsAuthComplete;
    public string type { get; set; }
    public string error { get; set; }
    public AuthorizationJson.Multifactor multifactorData { get; set; }

    // Compat: Assist expects this property name
    public bool IsAuthenticationSuccessful => bIsAuthComplete;
}

// Compat type expected by some consumers
public class AuthenticationResult : AuthenticationStatus { }


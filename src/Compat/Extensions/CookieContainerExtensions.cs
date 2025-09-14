using System.Collections;
using System.Net;
using System.Reflection;

namespace ValNet.Compat.Extensions;

public static class CookieContainerExtensions
{
    public static IEnumerable<Cookie> GetAllCookies(this CookieContainer container)
    {
        var cookies = new List<Cookie>();
        var table = (IDictionary)typeof(CookieContainer)
            .GetField("m_domainTable", BindingFlags.NonPublic | BindingFlags.Instance)!
            .GetValue(container)!;
        foreach (var key in table.Keys)
        {
            var pathList = table[key];
            var col = pathList?.GetType().GetProperty("Values")?.GetValue(pathList) as ICollection;
            if (col == null) continue;
            foreach (var c in col)
            {
                if (c is Cookie cookie)
                    cookies.Add(cookie);
                else if (c is CookieCollection cc)
                    foreach (Cookie ci in cc) cookies.Add(ci);
            }
        }
        return cookies;
    }
}


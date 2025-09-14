using System.Text.Json.Serialization;

namespace ValNet.Objects.Player;

public class MatchHistoryObj
{
    public string Subject { get; set; }
    public int BeginIndex { get; set; }
    public int EndIndex { get; set; }
    public int Total { get; set; }
    [JsonPropertyName("History")]
    public List<MatchHistoryMatch> MatchHistory { get; set; }

    // Compat: some consumers expect 'History' property name
    public List<MatchHistoryMatch> History
    {
        get => MatchHistory;
        set => MatchHistory = value;
    }
}
public class MatchHistoryMatch
{
    public string MatchID { get; set; }
    public object GameStartTime { get; set; }
    public string QueueID { get; set; }
}

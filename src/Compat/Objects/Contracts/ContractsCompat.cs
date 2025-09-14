using System.Text.Json.Serialization;

namespace ValNet.Objects.Contracts;

public class ContactsFetchObj
{
    [JsonPropertyName("Missions")] public List<Mission> Missions { get; set; } = new();

    public class MissionObj
    {
        [JsonPropertyName("ID")] public string ID { get; set; } = string.Empty;
        [JsonPropertyName("ExpirationTime")] public DateTime ExpirationTime { get; set; }
        [JsonPropertyName("Objectives")] public Dictionary<string, int> Objectives { get; set; } = new();
    }

    // Alias to match consumers expecting Mission type
    public class Mission : MissionObj { }
}

public class DailyTicketObj
{
    [JsonPropertyName("DailyRewards")] public DailyRewardsObj DailyRewards { get; set; } = new();

    public class DailyRewardsObj
    {
        [JsonPropertyName("Milestones")] public List<MilestoneObj> Milestones { get; set; } = new();
    }

    public class MilestoneObj
    {
        [JsonPropertyName("BonusApplied")] public bool BonusApplied { get; set; }
        [JsonPropertyName("Progress")] public int Progress { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace ValNet.Objects.Player;

public class PlayerMMRObj
{
    public long Version { get; set; }
    public string Subject { get; set; }
    
    [JsonPropertyName("NewPlayerExperienceFinished")]
    public bool bNewPlayerExperienceFinished { get; set; }
    
    [JsonPropertyName("QueueSkills")]
    public QueueSkillsData QueueSkills { get; set; }
    public CompetitiveUpdate LatestCompetitiveUpdate { get; set; }
    public bool IsLeaderboardAnonymized { get; set; }
    public bool IsActRankBadgeHidden { get; set; }
    
    
    public class QueueSkillsData
    {
        public Competitive competitive { get; set; }
        public Custom custom { get; set; }
        public Deathmatch deathmatch { get; set; }
        public Ggteam ggteam { get; set; }
        public Newmap newmap { get; set; }
        public Onefa onefa { get; set; }
        public Seeding seeding { get; set; }
        public Spikerush spikerush { get; set; }
        public Unrated unrated { get; set; }
        
        public class Custom
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class Deathmatch
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class Ggteam
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class Newmap
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class Onefa
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class Seeding
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class Spikerush
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }
    
    public class Unrated
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }
    
    public class Competitive
    {
        public int TotalGamesNeededForRating { get; set; }
        public int TotalGamesNeededForLeaderboard { get; set; }
        public int CurrentSeasonGamesNeededForRating { get; set; }
        public System.Collections.Generic.Dictionary<string, ActInformation> SeasonalInfoBySeasonID { get; set; }
    }

    public class ActInformation
    {
        public string SeasonID { get; set; }
        public int NumberOfWins { get; set; }
        public int NumberOfWinsWithPlacements { get; set; }
        public int NumberOfGames { get; set; }
        public int Rank { get; set; }
        public int CapstoneWins { get; set; }
        public int LeaderboardRank { get; set; }
        public int CompetitiveTier { get; set; }
        public int RankedRating { get; set; }
        public Dictionary<int,int> WinsByTier { get; set; }
        public int GamesNeededForRating { get; set; }
        public int TotalWinsNeededForRank { get; set; }
    }
    
    
    
    }
}


// Possible reuse in comp updates.
public class CompetitiveUpdate
{
    public string MatchID { get; set; }
    public string MapID { get; set; }
    public string SeasonID { get; set; }
    public long MatchStartTime { get; set; }
    public int TierAfterUpdate { get; set; }
    public int TierBeforeUpdate { get; set; }
    public int RankedRatingAfterUpdate { get; set; }
    public int RankedRatingBeforeUpdate { get; set; }
    public int RankedRatingEarned { get; set; }
    public int RankedRatingPerformanceBonus { get; set; }
    public string CompetitiveMovement { get; set; }
    public int AFKPenalty { get; set; }
}



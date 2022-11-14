namespace CityInfo.API.ViewModels.PlayerProfile
{
    public class EngagementStatistics
    {
        public string engagementStatus { get; set; }
        public int participated { get; set; }
        public int won { get; set; }
        public int lost { get; set; }
        public int success { get; set; }
        public int failure { get; set; }
        public int killedAndSuccess { get; set; }
        public int diedAndSuccess { get; set; }
        public int killedAndFailure { get; set; }
        public int diedAndFailure { get; set; }
    }
}

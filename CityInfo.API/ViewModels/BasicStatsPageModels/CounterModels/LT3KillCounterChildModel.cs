namespace CityInfo.API.ViewModels.BasicStatsPageModels.CounterModels
{
    public class LT3KillCounterChildModel
    {
        public string type { get; set; }
        public int total { get; set; }

        public List<L3TKillCountersPlayerBreakDown> l3TKillCountersPlayerBreakDowns = new List<L3TKillCountersPlayerBreakDown>();
    }
}

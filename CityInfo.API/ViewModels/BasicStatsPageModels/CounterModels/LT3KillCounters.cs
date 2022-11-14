namespace CityInfo.API.ViewModels.BasicStatsPageModels.CounterModels
{
    public class LT3KillCounters
    {
        public string teamCT { get; set; }
        public string teamT { get; set; }
        public List<LT3KillCounterChildModel> lT3KillCountersCT { get; set; }
        public List<LT3KillCounterChildModel> lT3KillCountersT { get; set; }
        public LT3KillCounters()
        {
            lT3KillCountersCT = new List<LT3KillCounterChildModel>();
            lT3KillCountersT = new List<LT3KillCounterChildModel>();
        }

    }
}

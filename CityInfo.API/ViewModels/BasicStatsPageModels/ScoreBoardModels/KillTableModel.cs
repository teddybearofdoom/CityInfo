namespace CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels
{
    public class KillTableModel
    {
        public string teamCTname { get; set; }

        public List<PlayerStats> team_CT;
        public string teamTname { get; set; }

        public List<PlayerStats> team_T;
        public KillTableModel()
        {
            teamCTname = " ";
            teamTname = " ";
            team_CT = new List<PlayerStats>();
            team_T = new List<PlayerStats>();
        }
    }
}

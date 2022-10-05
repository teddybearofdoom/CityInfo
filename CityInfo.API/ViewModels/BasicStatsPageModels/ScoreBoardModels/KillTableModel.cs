namespace CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels
{
    public class KillTableModel
    {
        public List<PlayerStats> team_CT;

        public List<PlayerStats> team_T;
        public KillTableModel()
        {
            team_CT = new List<PlayerStats>();
            team_T = new List<PlayerStats>();
        }
    }
}

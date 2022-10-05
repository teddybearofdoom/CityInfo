namespace CSGSI_FrontEnd.ViewModels.BasicStatsPageModels
{
    public class TeamEconomyStats
    {
        public EconomyStats teamCTEconomy { get; set; }
        public EconomyStats teamTEconomy { get; set; }
        public TeamEconomyStats()
        {
            teamCTEconomy = new EconomyStats();    
            teamTEconomy = new EconomyStats(); 
        }
    }
}

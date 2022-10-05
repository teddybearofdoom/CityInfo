namespace CSGSI_FrontEnd.ViewModels.BasicStatsPageModels
{
    public class EconomyTableModel
    {
        public TeamEconomyStats ecoRoundEconomy { get; set; }
        public TeamEconomyStats halfbuyRoundEconomy { get; set; }
        public TeamEconomyStats fullbuyRoundEconomy { get; set; }
        public TeamEconomyStats forcebuyRoundEconomy { get; set; }
        public TeamEconomyStats partialfullbuyRoundEconomy { get; set; }
        public TeamEconomyStats pistolRoundEconomy { get; set; }
        public TeamEconomyStats postPistolRoundEconomy { get; set; }
        public TeamEconomyStats breakRoundEconomy { get; set; }
        public EconomyTableModel()
        {
            ecoRoundEconomy = new TeamEconomyStats();
            halfbuyRoundEconomy = new TeamEconomyStats();
            fullbuyRoundEconomy = new TeamEconomyStats();
            forcebuyRoundEconomy = new TeamEconomyStats();
            pistolRoundEconomy = new TeamEconomyStats();
            partialfullbuyRoundEconomy= new TeamEconomyStats();
            breakRoundEconomy = new TeamEconomyStats();
            postPistolRoundEconomy = new TeamEconomyStats();
            
        }
    }
}

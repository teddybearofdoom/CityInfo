namespace CityInfo.API.ViewModels.EconomyModels
{
    public class EconomyTypeModels
    {
        public string teamName { get; set; }
        public EconomyStatsModel ecoRoundEconomy { get; set; }
        public EconomyStatsModel halfbuyRoundEconomy { get; set; }
        public EconomyStatsModel fullbuyRoundEconomy { get; set; }
        public EconomyStatsModel forcebuyRoundEconomy { get; set; }
        public EconomyStatsModel partialfullbuyRoundEconomy { get; set; }
        public EconomyStatsModel pistolRoundEconomy { get; set; }
        public EconomyStatsModel postPistolRoundEconomy { get; set; }
        public EconomyStatsModel breakRoundEconomy { get; set; }
        public EconomyTypeModels()
        {
            teamName = "";
            ecoRoundEconomy = new EconomyStatsModel();
            halfbuyRoundEconomy = new EconomyStatsModel();
            fullbuyRoundEconomy = new EconomyStatsModel();
            forcebuyRoundEconomy = new EconomyStatsModel();
            pistolRoundEconomy = new EconomyStatsModel();
            partialfullbuyRoundEconomy = new EconomyStatsModel();
            breakRoundEconomy = new EconomyStatsModel();
            postPistolRoundEconomy = new EconomyStatsModel();
        }
    }
}

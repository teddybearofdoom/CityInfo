
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    //Kills object to be used for Players & Teams in Historical database (deaths+engagements? temporarily removed)
    public class Kills
    {
        public Kills()
        {
            this.openingKill = new Deriv_Kill_BO();
            this.tradedKills = new List<Deriv_Kill_BO>();
            this.tradeKills = new List<Deriv_Kill_BO>();
            this.followUpFragTraded = new Deriv_Kill_BO();
            this.followUpFragUntraded = new Deriv_Kill_BO();
            this.firstResponseKill = new Deriv_Kill_BO();
            this.equalizers = new List<Deriv_Kill_BO>();
        }

        public Deriv_Kill_BO openingKill { get; set; }
        
        //Kills that got traded later on
        public List<Deriv_Kill_BO> tradedKills { get; set; }

        //Kills that you took which traded a previous one
        
        public List<Deriv_Kill_BO> tradeKills { get; set; }
        
        public Deriv_Kill_BO followUpFragTraded { get; set; }
        
        public Deriv_Kill_BO followUpFragUntraded { get; set; }
        
        public Deriv_Kill_BO firstResponseKill {get; set; }
        
        public List<Deriv_Kill_BO> equalizers {get; set; }

    }
}

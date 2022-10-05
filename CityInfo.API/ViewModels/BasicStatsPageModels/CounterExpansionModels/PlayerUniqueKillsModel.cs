using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CSGSI_FrontEnd.ViewModels.CounterExpansionModels
{
    public class PlayerUniqueKillsModel
    {
        public string name { get;set; }
        public string team { get;set; }
        public List<Deriv_Kill_BO> firstResponseKills { get; set; } 
        public List<Deriv_Kill_BO> firstResponseKillOpportunities { get; set; }
        public List<Deriv_Kill_BO> firstResponseKillsHistrorical { get; set; }

        public List<Deriv_Kill_BO> fourVfourEqualizerKills { get; set; }
        public List<Deriv_Kill_BO> fourVfourEqualizerKillOpportunities { get; set; }
        public List<Deriv_Kill_BO> fourVfourEqualizerKillsHistrorical { get; set; }

        public List<Deriv_Kill_BO> followUpFragsToKills { get; set; }
        public List<Deriv_Kill_BO> followUpFragsToKillOpportunities { get; set; }
        public List<Deriv_Kill_BO> followUpFragsToKillsHistrorical { get; set; }

        public List<Deriv_Kill_BO> followUpFragsUTKills { get; set; }
        public List<Deriv_Kill_BO> followUpFragsUTKillOpportunities { get; set; }
        public List<Deriv_Kill_BO> followUpFragsUTKillsHistrorical { get; set; }

        public List<Deriv_Kill_BO> tradedOpenersKills { get; set; }
        public List<Deriv_Kill_BO> tradedOpenersKillOpportunities { get; set; }
        public List<Deriv_Kill_BO> tradedOpenersKillsHistrorical { get; set; }

        public List<Deriv_Kill_BO> untradedOpenersKills { get; set; }
        public List<Deriv_Kill_BO> untradedOpenersKillOpportunities { get; set; }
        public List<Deriv_Kill_BO> untradedOpenersKillsHistrorical { get; set; }

        public PlayerUniqueKillsModel()
        {
            firstResponseKills = new List<Deriv_Kill_BO>();
            firstResponseKillOpportunities = new List<Deriv_Kill_BO>();
            firstResponseKillsHistrorical = new List<Deriv_Kill_BO>();
            
            fourVfourEqualizerKills = new List<Deriv_Kill_BO>();
            fourVfourEqualizerKillOpportunities = new List<Deriv_Kill_BO>();
            fourVfourEqualizerKillsHistrorical = new List<Deriv_Kill_BO>();
            
            followUpFragsToKills = new List<Deriv_Kill_BO>();
            followUpFragsToKillOpportunities = new List<Deriv_Kill_BO>();
            followUpFragsToKillsHistrorical = new List<Deriv_Kill_BO>();
            
            followUpFragsUTKills = new List<Deriv_Kill_BO>();
            followUpFragsUTKillOpportunities = new List<Deriv_Kill_BO>();
            followUpFragsUTKillsHistrorical = new List<Deriv_Kill_BO>();
            
            tradedOpenersKills = new List<Deriv_Kill_BO>();
            tradedOpenersKillOpportunities = new List<Deriv_Kill_BO>();
            tradedOpenersKillsHistrorical = new List<Deriv_Kill_BO>();

            untradedOpenersKills = new List<Deriv_Kill_BO>();
            untradedOpenersKillOpportunities = new List<Deriv_Kill_BO>();
            untradedOpenersKillsHistrorical = new List<Deriv_Kill_BO>();
        }
    }
}

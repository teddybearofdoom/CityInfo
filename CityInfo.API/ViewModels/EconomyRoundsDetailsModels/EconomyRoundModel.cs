using CityInfo.API.Models.BusinessObjects.DerivBO;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CSGSI_FrontEnd.ViewModels.EconomyRoundsDetailsModels
{
    public class EconomyRoundModel
    {
        public List<Deriv_RoundEconomyState_BO> State { get; set; }
        public Deriv_PlayerTeam_BO deriv_PlayerTeam_BO { get; set; }    
        public EconomyRoundModel()
        {
               State = new List<Deriv_RoundEconomyState_BO>();
               deriv_PlayerTeam_BO = new Deriv_PlayerTeam_BO();
        }
        public EconomyRoundModel(List<Deriv_RoundEconomyState_BO> state, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO)
        {
            State = state;
            this.deriv_PlayerTeam_BO = deriv_PlayerTeam_BO;
        }
    }
}

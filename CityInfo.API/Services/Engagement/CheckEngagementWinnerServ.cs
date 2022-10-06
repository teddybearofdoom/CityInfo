using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;

namespace CSGSI_FrontEnd.FrontEndServices.EngagmentServ
{
    public class CheckEngagementWinnerServ
    {
        public string Winner(int endEngagementCTPlayers, int endEngagementTPlayers, int startEngagementCTPlayers, int startEngagementTPlayers)
        {
            int playersLostCT = startEngagementCTPlayers - endEngagementCTPlayers;
            int playersLostT = startEngagementTPlayers - endEngagementTPlayers;
            if (playersLostCT > playersLostT)
            {
                return "T";

            }
            else if (playersLostT > playersLostCT)
            {
                return "CT";
            }
            else if (playersLostT == playersLostCT && startEngagementCTPlayers != startEngagementTPlayers)
            {
                if (endEngagementCTPlayers > endEngagementTPlayers)
                {
                    return "CT";
                }
                else if (endEngagementTPlayers > endEngagementCTPlayers)
                {
                    return "T";
                }
            }          
            return "T";
        }
        public string RoundWinner(Deriv_RoundCond_BO deriv_RoundCond_BO)
        {
            if (deriv_RoundCond_BO != null)
            {
                if (deriv_RoundCond_BO.win_team == "CT")
                {
                    return "CT";
                }
                else if (deriv_RoundCond_BO.win_team == "T")
                {
                    return "T";
                }
            }
            return null;
        }

    }
}

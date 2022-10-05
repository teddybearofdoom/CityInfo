
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CityInfo.API.FrontEndServices.KillPageServ
{
    public class EconomyFilters_ScoreBoard
    {
        public KillTableModel killTableModel { get; set; }
        public PopulateScoreBoardParts populateScoreBoardParts { get; set; }
        public PopulateScoreBoardServ populateScoreBoardServ { get; set; }
        public string FB { get; set; }
        public string HB { get; set; }
        public string Eco { get; set; }
        public string GunRound { get; set; }
        public string PartialGunRound { get; set; }
        public string GRAWP { get; set; }
        public string total { get; set; }
        public EconomyFilters_ScoreBoard(string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total)
        {
            populateScoreBoardParts = new PopulateScoreBoardParts();
            populateScoreBoardServ = new PopulateScoreBoardServ();
            killTableModel = new KillTableModel();
            this.FB = FB;
            this.HB = HB;
            this.Eco = Eco;
            this.GunRound = GunRound;
            this.PartialGunRound = PartialGunRound;
            this.GRAWP = GRAWP;
            this.total = total;
        }
        public bool CheckEconomyFilters()
        {
            if (FB == "on" || HB == "on" || Eco == "on" || PartialGunRound == "on" || GunRound == "on" || GRAWP == "on" || total == "on")
            {
                return true;
            }
            return false;
        }
        public void IntializeScoreBoardForEconomyFilters(Deriv_PlayerTeam_BO deriv_PlayerTeam_BO)
        {
            populateScoreBoardServ.IntializeScoreBoard(deriv_PlayerTeam_BO, killTableModel);
        }
        public void CheckEconomyFilters(Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO PreviousRoundderiv_PlayerTeam_BO, CSGO_GSI_Backend.Models.BusinessObjects.DerivBO.Deriv_RoundEconomyState_BO deriv_RoundEconomyState_BO, Deriv_AWP_BOs deriv_AWP_BOs)
        {
            if (Eco == "on")
            {
                checkEcoBuyCT(deriv_RoundEconomyState_BO.ecoBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkEcoBuyT(deriv_RoundEconomyState_BO.ecoBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
            }
            if (HB == "on")
            {
                checkHalfBuyCT(deriv_RoundEconomyState_BO.halfBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkHalfBuyT(deriv_RoundEconomyState_BO.halfBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
            }
            if (FB == "on")
            {
                checkForceBuyCT(deriv_RoundEconomyState_BO.forceBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkForceBuyT(deriv_RoundEconomyState_BO.forceBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
            }
            if (GunRound == "on")
            {
                checkGunRoundCT(deriv_RoundEconomyState_BO.fullBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkGunRoundT(deriv_RoundEconomyState_BO.fullBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
            }
            if (PartialGunRound == "on")
            {
                checkPartialGunRoundCT(deriv_RoundEconomyState_BO.partialfullBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkPartialGunRoundT(deriv_RoundEconomyState_BO.partialfullBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
            }
            if (GRAWP == "on")
            {
                checkGRAWPCT(deriv_RoundEconomyState_BO.fullBuyCT, killTableModel, deriv_PlayerTeam_BO, deriv_AWP_BOs.deriv_AWP_BO_CT, PreviousRoundderiv_PlayerTeam_BO);
                checkGRAWPT(deriv_RoundEconomyState_BO.fullBuyT, killTableModel, deriv_PlayerTeam_BO, deriv_AWP_BOs.deriv_AWP_BO_T, PreviousRoundderiv_PlayerTeam_BO);
            }
            if (total == "on")
            {
                checkEcoBuyCT(deriv_RoundEconomyState_BO.ecoBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkHalfBuyCT(deriv_RoundEconomyState_BO.halfBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkForceBuyCT(deriv_RoundEconomyState_BO.forceBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkGunRoundCT(deriv_RoundEconomyState_BO.fullBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkPartialGunRoundCT(deriv_RoundEconomyState_BO.partialfullBuyCT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkGRAWPCT(deriv_RoundEconomyState_BO.fullBuyCT, killTableModel, deriv_PlayerTeam_BO, deriv_AWP_BOs.deriv_AWP_BO_CT, PreviousRoundderiv_PlayerTeam_BO);

                checkEcoBuyT(deriv_RoundEconomyState_BO.ecoBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkHalfBuyT(deriv_RoundEconomyState_BO.halfBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkForceBuyT(deriv_RoundEconomyState_BO.forceBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkGunRoundT(deriv_RoundEconomyState_BO.fullBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkPartialGunRoundT(deriv_RoundEconomyState_BO.partialfullBuyT, killTableModel, deriv_PlayerTeam_BO, PreviousRoundderiv_PlayerTeam_BO);
                checkGRAWPT(deriv_RoundEconomyState_BO.fullBuyT, killTableModel, deriv_PlayerTeam_BO, deriv_AWP_BOs.deriv_AWP_BO_T, PreviousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkEcoBuyCT(bool EcoBuyCT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (EcoBuyCT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkEcoBuyT(bool EcoBuyT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (EcoBuyT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkHalfBuyCT(bool HalfBuyCT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (HalfBuyCT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkHalfBuyT(bool HalfBuyT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (HalfBuyT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkForceBuyCT(bool ForceBuyCT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (ForceBuyCT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkForceBuyT(bool ForceBuyT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (ForceBuyT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkGunRoundCT(bool GunRoundCT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (GunRoundCT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkGunRoundT(bool GunRoundT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (GunRoundT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkPartialGunRoundCT(bool PartialGunRoundCT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (PartialGunRoundCT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkPartialGunRoundT(bool PartialGunRoundT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (PartialGunRoundT == true)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkGRAWPCT(bool GunRoundCT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_AWP_BO deriv_AWP_BO_CT, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (GunRoundCT == true && deriv_AWP_BO_CT.AWP_ZERO == false)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
        public void checkGRAWPT(bool GunRoundT, KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_AWP_BO deriv_AWP_BO_T, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            if (GunRoundT == true && deriv_AWP_BO_T.AWP_ZERO == false)
            {
                populateScoreBoardParts.SetScoreBoard(killTableModel, deriv_PlayerTeam_BO, previousRoundderiv_PlayerTeam_BO);
            }
        }
    }

}

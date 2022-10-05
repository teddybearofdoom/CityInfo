using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CSGSI_FrontEnd.ViewModels.EconomyRoundsDetailsModels
{
    public class GameRoundEconomyStatusModel
    {
        public GameRoundEconomyStatusModel(string ecoBuyTeamA, string ecoBuyTeamB, string halfBuyTeamA, string halfBuyTeamB, string forceBuyTeamA, string forceBuyTeamB, string fullBuyTeamA, string fullBuyTeamB, string partialfullBuyTeamA, string partialfullBuyTeamB, string pistolRoundTeamA, string pistolRoundTeamB, string postPistolRoundTeamA, string postPistolRoundTeamB, string breakRoundTeamA, string breakRoundTeamB, string round)
        {
            this.ecoBuyTeamA = ecoBuyTeamA;
            this.ecoBuyTeamB = ecoBuyTeamB;
            this.halfBuyTeamA = halfBuyTeamA;
            this.halfBuyTeamB = halfBuyTeamB;
            this.forceBuyTeamA = forceBuyTeamA;
            this.forceBuyTeamB = forceBuyTeamB;
            this.fullBuyTeamA = fullBuyTeamA;
            this.fullBuyTeamB = fullBuyTeamB;
            this.partialfullBuyTeamA = partialfullBuyTeamA;
            this.partialfullBuyTeamB = partialfullBuyTeamB;
            this.pistolRoundTeamA = pistolRoundTeamA;
            this.pistolRoundTeamB = pistolRoundTeamB;
            this.postPistolRoundTeamA = postPistolRoundTeamA;
            this.postPistolRoundTeamB = postPistolRoundTeamB;
            this.breakRoundTeamA = breakRoundTeamA;
            this.breakRoundTeamB = breakRoundTeamB;
            Round = round;
        }
        public string ecoBuyTeamA { get; set; }
        public string ecoBuyTeamB { get; set; }
        public string halfBuyTeamA { get; set; }
        public string halfBuyTeamB { get; set; }
        public string forceBuyTeamA { get; set; }
        public string forceBuyTeamB { get; set; }
        public string fullBuyTeamA { get; set; }
        public string fullBuyTeamB { get; set; }
        public string partialfullBuyTeamA { get; set; }
        public string partialfullBuyTeamB { get; set; }
        public string pistolRoundTeamA { get; set; }
        public string pistolRoundTeamB { get; set; }
        public string postPistolRoundTeamA { get; set; }
        public string postPistolRoundTeamB { get; set; }
        public string breakRoundTeamA { get; set; }
        public string breakRoundTeamB { get; set; }
        public string Round { get; set; }

    }
}

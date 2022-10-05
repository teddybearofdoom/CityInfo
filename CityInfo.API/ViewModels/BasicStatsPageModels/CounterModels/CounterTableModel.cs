using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;

namespace CSGSI_FrontEnd.ViewModels.CounterModels
{
    public class CounterTableModel
    {
        public EconomyTableModel economyTableModel { get; set; }
        public UniqueKillStatsModel UniqueKillStatsModel { get; set; }
        public string teamCT { get; set; }
        public string teamT { get; set; }
        public CounterTableModel(EconomyTableModel economyTableModel, UniqueKillStatsModel UniqueKillStatsModel, string teamCT, string teamT)
        {
            this.economyTableModel = economyTableModel;
            this.UniqueKillStatsModel = UniqueKillStatsModel;
            this.teamCT = teamCT;
            this.teamT = teamT;
        }
    }
}

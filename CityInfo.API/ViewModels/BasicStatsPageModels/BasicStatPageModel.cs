using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CSGSI_FrontEnd.ViewModels.BasicStatsPageModels
{
    public class BasicStatPageModel
    {
        public KillTableModel KillTableModel { get; set; }
        public EconomyTableModel EconomyTableModel { get; set; }
        public UniqueKillStatsModel UniqueKillStatsModel { get; set; } 
        public CounterExpansionModel CounterExpansionModel { get; set; }
        public BasicStatPageModel()
        {
            KillTableModel = new KillTableModel();
            EconomyTableModel = new EconomyTableModel();
            UniqueKillStatsModel = new UniqueKillStatsModel();
            CounterExpansionModel = new CounterExpansionModel();
        }
    }
}

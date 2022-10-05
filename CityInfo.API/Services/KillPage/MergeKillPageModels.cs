using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CSGSI_FrontEnd.ViewModels.BasicStatsPageModels;
using CSGSI_FrontEnd.ViewModels.CounterExpansionModels;

namespace CityInfo.API.Services.KillPage
{
    public class MergeKillPageModels
    {
        public BasicStatPageModel basicStatPageModel { get; set; }
        public MergeKillPageModels()
        {
            basicStatPageModel = new BasicStatPageModel();
        }
        public BasicStatPageModel MergeBasicPageModels(KillTableModel killTableModel, EconomyTableModel economyTableModel, UniqueKillStatsModel uniqueKillStatsModel, CounterExpansionModel counterExpansionModel)
        {
            basicStatPageModel.KillTableModel = killTableModel;
            basicStatPageModel.EconomyTableModel = economyTableModel;
            basicStatPageModel.UniqueKillStatsModel = uniqueKillStatsModel;
            basicStatPageModel.CounterExpansionModel = counterExpansionModel;
            return basicStatPageModel;
        }
    }
}

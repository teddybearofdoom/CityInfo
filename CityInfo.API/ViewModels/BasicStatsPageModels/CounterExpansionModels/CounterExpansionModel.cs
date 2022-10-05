namespace CSGSI_FrontEnd.ViewModels.CounterExpansionModels
{
    public class CounterExpansionModel
    {
        public List<PlayerUniqueKillsModel> teamAList { get; set; }
        public List<PlayerUniqueKillsModel> teamBList { get; set; }
        public CounterExpansionModel()
        {
            teamAList = new List<PlayerUniqueKillsModel>();
            teamBList = new List<PlayerUniqueKillsModel>();
        }
    }
}

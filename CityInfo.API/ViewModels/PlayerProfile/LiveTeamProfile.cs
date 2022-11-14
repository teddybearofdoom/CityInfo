namespace CSGSI_FrontEnd.ViewModels.PlayerProfile
{
    public class LiveTeamProfile
    {
        public List<LivePlayerProfile> CTplayers { get; set; } 
        public List<LivePlayerProfile> Tplayers { get; set; }
        public LiveTeamProfile()
        {
            CTplayers = new List<LivePlayerProfile>();
            Tplayers = new List<LivePlayerProfile>();
        }
    }
}

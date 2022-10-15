namespace CityInfo.API.ViewModels.EconomyModels
{
    public class EconomyTable
    {
        public EconomyTypeModels teamCT { get; set; }
        public EconomyTypeModels teamT { get; set; }
        public EconomyTable()
        {
            teamCT = new EconomyTypeModels();
            teamT = new EconomyTypeModels();
        }
    }
}

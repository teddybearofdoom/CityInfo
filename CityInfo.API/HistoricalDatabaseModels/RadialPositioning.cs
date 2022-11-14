using CSGO_GSI_Backend.Models.BusinessObjects.RadialPosBO;

namespace CSGSI_FrontEnd.HistoricalDatabaseModels
{
    public class RadialPositioning
    {
        public List<RadialPos_Origin_BO> radialPos_Origin_BOs { get; set; }
        public RadialPositioning()
        {
            radialPos_Origin_BOs = new List<RadialPos_Origin_BO>();
        }
    }
}

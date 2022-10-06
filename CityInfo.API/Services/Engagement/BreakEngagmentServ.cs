using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using System.Reflection;

namespace CSGSI_FrontEnd.FrontEndServices.EngagmentServ
{
    public static class BreakEngagmentServ
    {
        public static string returnCTPlayers(Deriv_Engagement_BO deriv_Engagement_BO)
        {
            foreach (var field in typeof(Deriv_Engagement_BO).GetProperties(BindingFlags.Instance |
                                      BindingFlags.NonPublic |
                                      BindingFlags.Public))
            {
                    if (field.Name[0] == 'V' && field.GetValue(deriv_Engagement_BO).ToString() == "1" )
                    {
                        return field.Name[7].ToString();
                    }                
            }
            return null;
        }
        public static string returnTPlayers(Deriv_Engagement_BO deriv_Engagement_BO)
        {
            foreach (var field in typeof(Deriv_Engagement_BO).GetProperties(BindingFlags.Instance |
                          BindingFlags.NonPublic |
                          BindingFlags.Public))
            {
                if (field.Name[0] == 'V' && field.GetValue(deriv_Engagement_BO).ToString() == "1" )
                {
                    return field.Name[9].ToString();
                }
            }
            return null;
        }
    }
}

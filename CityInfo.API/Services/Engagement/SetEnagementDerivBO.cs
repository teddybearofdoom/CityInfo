using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;

namespace CSGSI_FrontEnd.FrontEndServices.EngagmentServ
{
    public static class SetEnagementDerivBO
    {
        public static void setEngagementStatistics(Deriv_Engagement_BO deriv_Engagement_BO, int CT_alive, int T_alive, float time, string phase, bool timerElapsed, int round)
        {
            deriv_Engagement_BO.timerElapsed = timerElapsed;
            deriv_Engagement_BO.round = round;
            if (timerElapsed == true)
            {
                deriv_Engagement_BO.endPhase = phase;
                deriv_Engagement_BO.endTime = time;
            }
            else
            {
                deriv_Engagement_BO.startPhase = phase;
                deriv_Engagement_BO.startTime = time;
            }
            if (CT_alive == 5 && T_alive == 5)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_5v5 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_5v5 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function


                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;


                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;

            }

            if (CT_alive == 4 && T_alive == 5)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_4v5 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_4v5 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 3 && T_alive == 5)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_3v5 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_3v5 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 2 && T_alive == 5)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_2v5 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_2v5 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 1 && T_alive == 5)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_1v5 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_1v5 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 0 && T_alive == 5)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_0v5 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_0v5 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 4 && T_alive == 4)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_4v4 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_4v4 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 3 && T_alive == 4)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_3v4 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_3v4 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 2 && T_alive == 4)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_2v4 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_2v4 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 1 && T_alive == 4)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_1v4 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_1v4 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_4v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 0 && T_alive == 4)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_0v4 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_0v4 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;
                deriv_Engagement_BO.versus_4v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 3 && T_alive == 3)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_3v3 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_3v3 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;


                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 2 && T_alive == 3)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_2v3 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_2v3 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;


                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 1 && T_alive == 3)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_1v3 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_1v3 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;


                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_3v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 0 && T_alive == 3)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_0v3 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_0v3 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;


                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;
                deriv_Engagement_BO.versus_3v3 = false;

                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 2 && T_alive == 2)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_2v2 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_2v2 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;


                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 1 && T_alive == 2)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_1v2 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_1v2 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;


                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 0 && T_alive == 2)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_0v2 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_0v2 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;


                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 0 && T_alive == 1)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_0v1 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_0v1 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function


                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;

                deriv_Engagement_BO.versus_2v2 = false;



                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 1 && T_alive == 1)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_1v1 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_1v1 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;



                deriv_Engagement_BO.versus_2v1 = false;
                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 1 && T_alive == 0)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_1v0 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_1v0 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;

                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 2 && T_alive == 1)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_2v1 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_2v1 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;


                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 2 && T_alive == 0)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_2v0 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_2v0 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_1v1 = false;


                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 3 && T_alive == 2)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_3v2 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_3v2 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;


                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 3 && T_alive == 1)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_3v1 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_3v1 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;


                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 3 && T_alive == 0)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_3v0 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_3v0 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;

                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 4 && T_alive == 3)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_4v3 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_4v3 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;


                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 4 && T_alive == 2)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_4v2 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_4v2 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;

                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 4 && T_alive == 1)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_4v1 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_4v1 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 4 && T_alive == 0)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_4v0 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_4v0 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 5 && T_alive == 4)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_5v4 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_5v4 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;



                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 5 && T_alive == 3)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_5v3 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_5v3 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;



                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 5 && T_alive == 2)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_5v2 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_5v2 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;



                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }

            if (CT_alive == 5 && T_alive == 1)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_5v1 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_5v1 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;
                deriv_Engagement_BO.versus_5v0 = false;

                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v4 = false;
            }

            if (CT_alive == 5 && T_alive == 0)
            {
                //set the engagement count variable to 1 
                deriv_Engagement_BO.Versus_5v0 = 1;

                //and set engagement bool state variable to true
                deriv_Engagement_BO.versus_5v0 = true;

                //rest of state variables to false
                //this functionality is to be shifted to a timer function

                deriv_Engagement_BO.versus_0v1 = false;
                deriv_Engagement_BO.versus_0v2 = false;
                deriv_Engagement_BO.versus_0v3 = false;
                deriv_Engagement_BO.versus_0v4 = false;
                deriv_Engagement_BO.versus_0v5 = false;
                deriv_Engagement_BO.versus_1v0 = false;
                deriv_Engagement_BO.versus_2v0 = false;
                deriv_Engagement_BO.versus_3v0 = false;
                deriv_Engagement_BO.versus_4v0 = false;


                deriv_Engagement_BO.versus_4v5 = false;
                deriv_Engagement_BO.versus_5v5 = false;
                deriv_Engagement_BO.versus_2v5 = false;
                deriv_Engagement_BO.versus_1v5 = false;
                deriv_Engagement_BO.versus_3v5 = false;

                deriv_Engagement_BO.versus_4v4 = false;
                deriv_Engagement_BO.versus_3v4 = false;
                deriv_Engagement_BO.versus_2v4 = false;
                deriv_Engagement_BO.versus_1v4 = false;

                deriv_Engagement_BO.versus_3v3 = false;
                deriv_Engagement_BO.versus_2v3 = false;
                deriv_Engagement_BO.versus_1v3 = false;

                deriv_Engagement_BO.versus_1v2 = false;
                deriv_Engagement_BO.versus_2v2 = false;

                deriv_Engagement_BO.versus_1v1 = false;
                deriv_Engagement_BO.versus_2v1 = false;

                deriv_Engagement_BO.versus_3v2 = false;
                deriv_Engagement_BO.versus_3v1 = false;

                deriv_Engagement_BO.versus_4v3 = false;
                deriv_Engagement_BO.versus_4v2 = false;
                deriv_Engagement_BO.versus_4v1 = false;

                deriv_Engagement_BO.versus_5v3 = false;
                deriv_Engagement_BO.versus_5v2 = false;
                deriv_Engagement_BO.versus_5v4 = false;
                deriv_Engagement_BO.versus_5v1 = false;
            }
        }

    }
}

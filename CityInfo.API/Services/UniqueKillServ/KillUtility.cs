using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using CSGSI_FrontEnd.Utility;
using CityInfo.API.Services.DatabaseServ;

public static class KillUtilities
{
    //Returns whether the kill had been traded or not.
    public static bool GetIsTraded(int killIndex, List<Deriv_Kill_BO> roundKills, ServerDataBase serverDataBase)
    {
        var checkKill = roundKills[killIndex];
        for (int killIdx = killIndex + 1; killIdx < roundKills.Count; killIdx++)
        {
            if (Util.GetTimeDiff(checkKill.phase, checkKill.time, roundKills[killIdx].phase, roundKills[killIdx].time, checkKill.round, serverDataBase) <= 5.0)
            {
                return true;
            }
        }
        return false;
    }

    //Return the kill which traded the killIndex kill.
    public static Deriv_Kill_BO GetTradingKill(int killIndex, List<Deriv_Kill_BO> roundKills, ServerDataBase serverDataBase)
    {
        var checkKill = roundKills[killIndex];
        for (int killIdx = killIndex + 1; killIdx < roundKills.Count; killIdx++)
        {
            if (Util.GetTimeDiff(checkKill.phase, checkKill.time, roundKills[killIdx].phase, roundKills[killIdx].time, checkKill.round, serverDataBase) <= 5.0)
            {
                return roundKills[killIdx];
            }
        }
        return null;
    }

    //Return if the kill equalizes game state or not (without being traded).
    public static bool GetIsEqualizer(int killIndex, List<Deriv_Kill_BO> roundKills, ServerDataBase serverDataBase)
    {
        var countCT = 5;
        var countT = 5;
        for (int killIdx = 0; killIdx <= killIndex; killIdx++)
        {
            //Update player counts
            if (roundKills[killIdx].victim_Player_Team == "CT")
                countCT--;
            else if (roundKills[killIdx].victim_Player_Team == "T")
                countT--;
        }
        if (countCT == countT && countCT != 5 && countT != 5)
        {
            if (GetIsTraded(killIndex, roundKills, serverDataBase) == false)
            {
                return true;
            }
        }
        return false;
    }
    //Return if the kill equalizes game state or not (without being traded).
    public static bool GetIs4v4Equalizer(int killIndex, List<Deriv_Kill_BO> roundKills, ServerDataBase serverDataBase)
    {
        var countCT = 5;
        var countT = 5;
        for (int killIdx = 0; killIdx < 2; killIdx++)
        {
            //Update player counts
            if (roundKills[killIdx].victim_Player_Team == "CT")
                countCT--;
            else if (roundKills[killIdx].victim_Player_Team == "T")
                countT--;
        }
        if (countCT == countT && countCT != 5 && countT != 5 && countCT == 4 && countT == 4)
        {
            if (GetIsTraded(killIndex, roundKills, serverDataBase) == false)
            {
                return true;
            }
        }
        return false;
    }

    //Return First Response Kill from a List of Round Kill Objects.
    public static Deriv_Kill_BO GetFirstResponseKill(List<Deriv_Kill_BO> deriv_Kill_BOs)
    {
        if (deriv_Kill_BOs.Count >= 2)
        {
            var responding_team = deriv_Kill_BOs[0].victim_Player_Team;

            for(int killIdx = 1; killIdx < deriv_Kill_BOs.Count; killIdx++){
                var roundKill = deriv_Kill_BOs[killIdx];

                if (roundKill.killing_Player_Team == responding_team)
                {
                    return roundKill;
                }
            }
        }
        return null;
    }

    //Return the first Kill from a List of round Kill Objects.
    public static Deriv_Kill_BO GetOpeningKill(List<Deriv_Kill_BO> deriv_Kill_BOs)
    {
        if (deriv_Kill_BOs.Count >= 1)
        {
            return deriv_Kill_BOs[0];
        }
        return null;
    }

    //Return the Follow Up Frag from a List of round Kill Objects if it was Traded.
    public static Deriv_Kill_BO GetFollowUpFragTraded(List<Deriv_Kill_BO> deriv_Kill_BOs, ServerDataBase serverDataBase)
    {
        if (deriv_Kill_BOs.Count >= 2)
        {
            if (deriv_Kill_BOs[0].killing_Player_Team == deriv_Kill_BOs[1].killing_Player_Team)
            {
                if (GetIsTraded(1, deriv_Kill_BOs, serverDataBase))
                {
                    return deriv_Kill_BOs[1];
                }
            }
        }
        return null;
    }

    //Return the Follow Up Frag from a List of round Kill Objects if it was Untraded.
    public static Deriv_Kill_BO GetFollowUpFragUntraded(List<Deriv_Kill_BO> deriv_Kill_BOs, ServerDataBase serverDataBase)
    {
        if (deriv_Kill_BOs.Count >= 2)
        {
            if (deriv_Kill_BOs[0].killing_Player_Team == deriv_Kill_BOs[1].killing_Player_Team)
            {
                if (GetIsTraded(1, deriv_Kill_BOs, serverDataBase) == false)
                {
                    return deriv_Kill_BOs[1];
                }
            }
        }
        return null;
    }
}

using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO;

namespace CityInfo.API.Services.KillPage.ScoreBoard
{
    public class PopulateScoreBoardParts
    {
        public void SetScoreBoard(KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO)
        {
            //Checking through for each player across all teams for when they switch sides 
            //That is player started in CT Team and switches to T after mid and vice versa

            //Player Stats - except assists 

            foreach (var playerstats in killTableModel.team_T)
            {
                foreach (var player in deriv_PlayerTeam_BO.Tplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                foreach (var player in deriv_PlayerTeam_BO.Tplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }
            foreach (var playerstats in killTableModel.team_T)
            {
                foreach (var player in deriv_PlayerTeam_BO.CTplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                foreach (var player in deriv_PlayerTeam_BO.CTplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }

            //Player Assists

            foreach (var playerstats in killTableModel.team_T)
            {
                for (int i = 0; i < 5; i++)
                {
                    PlayerAssists(playerstats, deriv_PlayerTeam_BO.Tplayers[i]);
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                for (int i = 0; i < 5; i++)
                {
                    PlayerAssists(playerstats, deriv_PlayerTeam_BO.Tplayers[i]);
                }
            }

            foreach (var playerstats in killTableModel.team_T)
            {
                for (int i = 0; i < 5; i++)
                {
                    PlayerAssists(playerstats, deriv_PlayerTeam_BO.CTplayers[i]);
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                for (int i = 0; i < 5; i++)
                {
                    PlayerAssists(playerstats, deriv_PlayerTeam_BO.CTplayers[i]);
                }
            }
        }
        public void SetScoreBoard(KillTableModel killTableModel, Deriv_PlayerTeam_BO deriv_PlayerTeam_BO, Deriv_PlayerTeam_BO previousRoundderiv_PlayerTeam_BO)
        {
            //Checking through for each player across all teams for when they switch sides 
            //That is player started in CT Team and switches to T after mid and vice versa

            //Player Stats - except assists 

            foreach (var playerstats in killTableModel.team_T)
            {
                foreach (var player in deriv_PlayerTeam_BO.Tplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                foreach (var player in deriv_PlayerTeam_BO.Tplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }
            foreach (var playerstats in killTableModel.team_T)
            {
                foreach (var player in deriv_PlayerTeam_BO.CTplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                foreach (var player in deriv_PlayerTeam_BO.CTplayers)
                {
                    PlayerStats(playerstats, player);
                }
            }

            //Player Assists

            foreach (var playerstats in killTableModel.team_T)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (previousRoundderiv_PlayerTeam_BO != null)
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.Tplayers[i], previousRoundderiv_PlayerTeam_BO.Tplayers[i]);
                    }
                    else
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.Tplayers[i]);
                    }
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (previousRoundderiv_PlayerTeam_BO != null)
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.Tplayers[i], previousRoundderiv_PlayerTeam_BO.Tplayers[i]);
                    }
                    else
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.Tplayers[i]);
                    }
                }
            }



            foreach (var playerstats in killTableModel.team_T)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (previousRoundderiv_PlayerTeam_BO != null)
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.CTplayers[i], previousRoundderiv_PlayerTeam_BO.CTplayers[i]);
                    }
                    else
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.CTplayers[i]);
                    }
                }
            }
            foreach (var playerstats in killTableModel.team_CT)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (previousRoundderiv_PlayerTeam_BO != null)
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.CTplayers[i], previousRoundderiv_PlayerTeam_BO.CTplayers[i]);
                    }
                    else
                    {
                        PlayerAssists(playerstats, deriv_PlayerTeam_BO.CTplayers[i]);
                    }
                }
            }
        }
        public void PlayerStats(PlayerStats playerstats, Base_GameState_Player_BO player)
        {
            if (playerstats.name == player.Name)
            {
                playerstats.Clan = player.Clan;
                playerstats.kills = playerstats.kills + player.playerCond_BO.round_kills;
                if (player.playerCond_BO.health == 0)
                {
                    playerstats.deaths++;
                }
                playerstats.adr = playerstats.adr + player.playerCond_BO.round_totaldmg;
            }
        }
        public void PlayerAssists(PlayerStats playerstats, Base_GameState_Player_BO player, Base_GameState_Player_BO PreviousRoundplayer)
        {
            if (playerstats.name == player.Name && player.Name == PreviousRoundplayer.Name)
            {
                playerstats.assist = playerstats.assist + (player.playerStats_BO.assists - PreviousRoundplayer.playerStats_BO.assists);
            }
        }
        public void PlayerAssists(PlayerStats playerstats, Base_GameState_Player_BO player)
        {
            if (playerstats.name == player.Name)
            {
                playerstats.assist = player.playerStats_BO.assists;
            }
        }
    }
}

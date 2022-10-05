using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.BaseGameStateBO
{
    public class Base_GameState_Players_BO
    {
        /// <summary>
        /// List containing all players
        /// </summary>
        public List<Base_GameState_Player_BO> player_BOs { get; set; } 
        /// <summary>
        /// Singular player object that is initialized for the list from AllPlayersNode to be populated 
        /// into the List defined as 'player_BOs' hence player_BO obj is JSON ignored and does NOT
        /// need to be serialized
        /// </summary>
        [JsonIgnore]
        Base_GameState_Player_BO player_BO { get; set; } 

        /// <summary>
        /// player_BOs (List) is initialized 
        /// foreach loop is run for the playerNodes coming in from payload that contain player list
        /// in the foreach loop the JSON ignored player_BO is initialized for each player in the player list 
        /// then that player_BO is populated using deserialization of the particular player being iterated 
        /// and then that player is added to the player_BOs LIST 
        /// </summary>
        /// <param name="playerNodes">Player list coming from GSI payload</param>
      
    }
}

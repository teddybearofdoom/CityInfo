using CSGSI_FrontEnd.HistoricalDatabaseModels.EngagementModels;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSGO_GSI_Backend.Models.BusinessObjects.DerivBO
{
    /// <summary>
    /// Deriv object that is to record engagements CT(players) vs
    /// T(players) 
    /// </summary>
    public class Deriv_Engagement_BO
    {
        public List<PlayersInfo> playersalive { get; set; }
        public List<PlayersInfo> playersdead { get; set; }
        public Deriv_Kill_BO Initiationkill { get; set; }
        public List<Deriv_Kill_BO> KillsInEngagements { get; set; }
        public float startTime { get; set; }
        public string startPhase { get; set; }
        public float endTime { get; set; }
        public string endPhase { get; set; }
        public bool timerElapsed { get; set; }
        public int round { get; set; }
        public int Versus_5v5 { get; set; }
        public int Versus_4v5 { get; set; }
        public int Versus_3v5 { get; set; }
        public int Versus_2v5 { get; set; }
        public int Versus_1v5 { get; set; }
        public int Versus_0v5 { get; set; }
        public int Versus_4v4 { get; set; }
        public int Versus_3v4 { get; set; }
        public int Versus_2v4 { get; set; }
        public int Versus_1v4 { get; set; }
        public int Versus_0v4 { get; set; }
        public int Versus_3v3 { get; set; }
        public int Versus_2v3 { get; set; }
        public int Versus_1v3 { get; set; }
        public int Versus_0v3 { get; set; }
        public int Versus_2v2 { get; set; }
        public int Versus_1v2 { get; set; }
        public int Versus_0v2 { get; set; }
        public int Versus_0v1 { get; set; }
        public int Versus_1v1 { get; set; }
        public int Versus_1v0 { get; set; }
        public int Versus_2v1 { get; set; }
        public int Versus_2v0 { get; set; }
        public int Versus_3v2 { get; set; }
        public int Versus_3v1 { get; set; }
        public int Versus_3v0 { get; set; }
        public int Versus_4v3 { get; set; }
        public int Versus_4v2 { get; set; }
        public int Versus_4v1 { get; set; }
        public int Versus_4v0 { get; set; }
        public int Versus_5v4 { get; set; }
        public int Versus_5v3 { get; set; }
        public int Versus_5v2 { get; set; }
        public int Versus_5v1 { get; set; }
        public int Versus_5v0 { get; set; }
        public bool versus_5v5 { get; set; }
        public bool versus_4v5 { get; set; }
        public bool versus_3v5 { get; set; }
        public bool versus_2v5 { get; set; }
        public bool versus_1v5 { get; set; }
        public bool versus_0v5 { get; set; }
        public bool versus_4v4 { get; set; }
        public bool versus_3v4 { get; set; }
        public bool versus_2v4 { get; set; }
        public bool versus_1v4 { get; set; }
        public bool versus_0v4 { get; set; }
        public bool versus_3v3 { get; set; }
        public bool versus_2v3 { get; set; }
        public bool versus_1v3 { get; set; }
        public bool versus_0v3 { get; set; }
        public bool versus_2v2 { get; set; }
        public bool versus_1v2 { get; set; }
        public bool versus_0v2 { get; set; }
        public bool versus_0v1 { get; set; }
        public bool versus_1v1 { get; set; }
        public bool versus_1v0 { get; set; }
        public bool versus_2v1 { get; set; }
        public bool versus_2v0 { get; set; }
        public bool versus_3v2 { get; set; }
        public bool versus_3v1 { get; set; }
        public bool versus_3v0 { get; set; }
        public bool versus_4v3 { get; set; }
        public bool versus_4v2 { get; set; }
        public bool versus_4v1 { get; set; }
        public bool versus_4v0 { get; set; }
        public bool versus_5v4 { get; set; }
        public bool versus_5v3 { get; set; }
        public bool versus_5v2 { get; set; }
        public bool versus_5v1 { get; set; }
        public bool versus_5v0 { get; set; }
        [BsonId]
        public ObjectId Id { get; set; }
        public Deriv_Engagement_BO()
        {
            playersalive = new List<PlayersInfo>();
            playersdead = new List<PlayersInfo>();
            Initiationkill = new Deriv_Kill_BO();
            KillsInEngagements = new List<Deriv_Kill_BO>();
        }
    }
}

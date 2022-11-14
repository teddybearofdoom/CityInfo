using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.Engagement;
using CityInfo.API.Services.Functions;
using CityInfo.API.Services.KillPage;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.Services.UniqueKillServ;
using CityInfo.API.ViewModels.BasicStatsPageModels.CounterModels;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CityInfo.API.ViewModels.EconomyModels;
using CSGSI_FrontEnd.FrontEndServices.EngagmentServ;
using CSGSI_FrontEnd.FrontEndServices.KillPageServ;
using CSGSI_FrontEnd.FrontEndServices.PlayerProfileServ;
using CSGSI_FrontEnd.Models;
using CSGSI_FrontEnd.ViewModels.EconomyRoundsDetailsModels;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CityInfo.API.Controllers.LiveControllers
{
    [Route("api/livetables/")]
    [ApiController]
    public class LiveTablesController : Controller
    {
        private readonly ILogger<LiveTablesController> _logger;
        private MongoClient mongoClient { get; set; }
        private IMongoDatabase mongoDatabase { get; set; }
        private ServerDataBase serverDataBase { get; set; }
        public LiveTablesController()
        {
            //_logger = logger;

            mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            mongoDatabase = mongoClient.GetDatabase("Astralis-vs-BIG");

            serverDataBase = new ServerDataBase(mongoDatabase);
        }

        [HttpPost("/ScoreBoard/{FirstHalf}/{SecondHalf}/{FullTime}/{OT}/{FB}/{HB}/{Eco}/{GunRound}/{PartialGunRound}/{GRAWP}/{total}/{Phase}/{RoundX}/{RoundY}/{timestamp}/{Round}")]
        public ActionResult ScoreBoardWithFilters(string FirstHalf, string SecondHalf, string FullTime, string OT, string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total, int RoundX, int RoundY, float timestamp, string Phase, int Round)
        {
            ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

            KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(FirstHalf, SecondHalf, FullTime, OT, FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total, RoundX, RoundY, timestamp, Phase, Round, serverDataBase);
            return Ok(JsonConvert.SerializeObject(killTableModel));
        }
        [HttpPost("/ScoreBoard")]
        public ActionResult ScoreBoard()
        {
            string FirstHalf = null;
            string SecondHalf = null;
            string FullTime = "on";
            string OT = null;
            string FB = null; string HB = null;
            string Eco = null;
            string GunRound = null;
            string PartialGunRound = null;
            string GRAWP = null;
            string total = null;
            int RoundX = 0;
            int RoundY = 0;
            float timestamp = 0;
            string Phase = null;
            int Round = 0;

            ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

            KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(FirstHalf, SecondHalf, FullTime, OT, FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total, RoundX, RoundY, timestamp, Phase, Round, serverDataBase);
            return Ok(JsonConvert.SerializeObject(killTableModel));
        }
        [HttpPost("/killcountertable")]
        public ActionResult KillCounterTable()
        {
            string FH = null;
            string SH = null;
            string FT = "on";
            string ot = null;
            int totalRoundCount = serverDataBase.GetTotalRoundCount();
            CounterServ counterServ = new CounterServ(FH, SH, FT, ot, totalRoundCount);
            counterServ.CheckFiltersCounterTable(serverDataBase);
            
            PopulateLT3KillCounterModel populateLT3KillCounterModel = new PopulateLT3KillCounterModel();
            populateLT3KillCounterModel.IntializeLT3KillCounterModel(serverDataBase);

            return Ok(populateLT3KillCounterModel.PopulateModelFullTime(counterServ.uniqueKillStatsModel,serverDataBase));
        }
        [HttpPost("/economy")]
        public ActionResult economy()
        {
            EconomyTableServ economyTableServ = new EconomyTableServ();
            economyTableServ.SetEcononmyTable(serverDataBase);

            return Ok(JsonConvert.SerializeObject(economyTableServ.economyTable));
        }
        [HttpPost("/player/{name}")]
        public ActionResult PlayerProfile(string Name)
        {
            PlayerProfileServices playerProfileServices = new PlayerProfileServices();
            var LiveTeamProfiles = playerProfileServices.PopulateTeamProfiles(serverDataBase);

            CalcEngagementForLivePlayerProfile calcEngagementForLivePlayerProfile = new CalcEngagementForLivePlayerProfile();
            for (int i = 0; i < serverDataBase.GetTotalRoundCount(); i++)
            {
                calcEngagementForLivePlayerProfile.CumulativeStatistics(LiveTeamProfiles, serverDataBase, i);
            }

            foreach (var player in LiveTeamProfiles.CTplayers)
            {
                if (player.Name == Name)
                {
                    return Ok(JsonConvert.SerializeObject(player));
                }
            }
            foreach (var player in LiveTeamProfiles.Tplayers)
            {
                if (player.Name == Name)
                {
                    return Ok(JsonConvert.SerializeObject(player));
                }
            }
            return Ok();
        }
    }
}

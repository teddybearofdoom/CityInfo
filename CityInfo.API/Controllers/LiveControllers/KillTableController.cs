
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Services.DatabaseServ;
using CityInfo.API.Services.Functions;
using CityInfo.API.Services.KillPage;
using CityInfo.API.Services.KillPage.ScoreBoard;
using CityInfo.API.ViewModels.BasicStatsPageModels.ScoreBoardModels;
using CityInfo.API.ViewModels.EconomyModels;
using CSGSI_FrontEnd.FrontEndServices.EngagmentServ;
using CSGSI_FrontEnd.FrontEndServices.KillPageServ;
using CSGSI_FrontEnd.Models;
using CSGSI_FrontEnd.ViewModels.EconomyRoundsDetailsModels;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CityInfo.API.Controllers
{
    [Route("api/livetables/")]
    [ApiController]
    public class KillTableController : ControllerBase
    {
        private readonly ILogger<KillTableController> _logger;
        private MongoClient mongoClient { get; set; }
        private IMongoDatabase mongoDatabase { get; set; }
        private ServerDataBase serverDataBase { get; set; }
        private string _configurationg { get; set; }
        private string _envName { get; set; }

        public KillTableController(string[] ConfigurationValue, ILogger<KillTableController> logger)
        {
            _logger = logger;
            _envName = ConfigurationValue[0];
            _configurationg = ConfigurationValue[1];
            //_logger = logger;
            mongoClient = new MongoClient(_envName);
            mongoDatabase = mongoClient.GetDatabase("astralis-vs-big-live");
            
            serverDataBase = new ServerDataBase(mongoDatabase);
        }
        [HttpGet("hit")]
        public ActionResult test()
        {
            if(string.IsNullOrEmpty(_envName))
            {
                return Ok(_configurationg);
            }
            else
            {
                return Ok(_envName);
            }
            
        }

        [HttpGet("killTable/{FirstHalf}/{SecondHalf}/{FullTime}/{OT}/{FB}/{HB}/{Eco}/{GunRound}/{PartialGunRound}/{GRAWP}/{total}/{RoundX}/{RoundY}/{timestamp}/{Phase}/{Round}")]
        public ActionResult postKillTable(string FirstHalf, string SecondHalf, string FullTime, string OT, string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total, int RoundX, int RoundY, float timestamp, string Phase, int Round)
        {
            ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

            KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(FirstHalf, SecondHalf, FullTime, OT, FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total, RoundX, RoundY, timestamp, Phase, Round, serverDataBase);
            return Ok(JsonConvert.SerializeObject(killTableModel));
        }
        [HttpGet("homepage/{FH}/{SH}/{FT}/{ot}")]
        public ActionResult postKillTable2(string FirstHalf, string SecondHalf, string FullTime, string OT, string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total, int RoundX, int RoundY, float timestamp, string Phase, int Round)
        {
            List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();

            ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

            KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(FirstHalf, SecondHalf, FullTime, OT, FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total, RoundX, RoundY, timestamp, Phase, Round, serverDataBase);

            CounterServ counterServ = new CounterServ();
            counterServ.SetFullTimeCounterTable(serverDataBase);

            CounterExpansionServ counterExpansionServ = new CounterExpansionServ();
            counterExpansionServ.SetFullTimeCounterExpansionTable(serverDataBase);

            MergeKillPageModels mergeKillPageModels = new MergeKillPageModels();

            return Ok(JsonConvert.SerializeObject(mergeKillPageModels.MergeBasicPageModels(killTableModel, counterServ.economyTableModel, counterServ.uniqueKillStatsModel, counterExpansionServ.counterExpansionModel)));
        }
        [HttpPost("/counterexpansion")]
        public ActionResult CounterExpansionTable()
        {
            string FirstHalf = null;
            string SecondHalf = null;
            string FullTime = null;
            string OT = null;
            int totalRound = serverDataBase.GetTotalRoundCount();
            CounterExpansionServ counterExpansionServ = new CounterExpansionServ(FirstHalf, SecondHalf, FullTime, OT, totalRound);
            counterExpansionServ.CheckFiltersCounterExpansionTable(serverDataBase);
            return Ok(JsonConvert.SerializeObject(counterExpansionServ.counterExpansionModel));
        }
        [HttpPost("/killcountertable")]
        public ActionResult KillCounterTable()
        {
            CounterServ counterServ = new CounterServ();
            counterServ.SetFullTimeCounterTable(serverDataBase);
            counterServ.uniqueKillStatsModel.teamCT = "Astralis";
            counterServ.uniqueKillStatsModel.teamT = "BIG";
            return Ok(counterServ.uniqueKillStatsModel);
        }
        [HttpPost("/economy")]
        public ActionResult economy()
        {
            EconomyTableServ economyTableServ = new EconomyTableServ();
            economyTableServ.SetEcononmyTable(serverDataBase);

            return Ok(JsonConvert.SerializeObject(economyTableServ.economyTable));
        }
        [HttpPost("/killtable")]
        public ActionResult KillTable()
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
            killTableModel.teamCTname = killTableModel.team_CT[0].Clan;
            killTableModel.teamTname = killTableModel.team_T[0].Clan;
            return Ok(JsonConvert.SerializeObject(killTableModel));
        }
        [HttpPost("/engagementtable")]
        public ActionResult engagementtable()
        {
            CalcEngagmentServ calcEngagmentServ = new CalcEngagmentServ();
            calcEngagmentServ.Engagment(serverDataBase);
            List<Engagement> engagementList = new List<Engagement>();
            engagementList.Add(calcEngagmentServ.engagementCT);
            engagementList.Add(calcEngagmentServ.engagementT);

            return Ok(JsonConvert.SerializeObject(engagementList));
        }
        [HttpPost("/economytable/{FH}/{SH}/{FT}/{ot}")]
        public ActionResult MatchSegmentsCountersTable(string FH, string SH, string FT, string ot)
        {
            int totalRoundCount = serverDataBase.GetTotalRoundCount();
            CounterServ counterServ = new CounterServ(FH, SH, FT, ot, totalRoundCount);
            //CounterServ counterServ = new CounterServ();
            counterServ.SetFullTimeCounterTable(serverDataBase);
            counterServ.MergeModels(serverDataBase);

            return Ok(JsonConvert.SerializeObject(counterServ.economyTableModel));
        }
        //[HttpPost("/player/{name}")]
        //public ActionResult PlayerProfile(string name)
        //{

        //}

        [HttpGet("economyround")]
        public ActionResult EconomyRoundsDetails()
        {
            ServerDataBase serverDataBase = new ServerDataBase(mongoDatabase);
            var collection = serverDataBase.GetRoundEconomyStateCollection();
            var DerivPlayer = serverDataBase.GetPlayerTeamDerivObj(1);
            var amazing = collection.AsQueryable().ToList();

            EconomyRoundModel economyRoundModel = new EconomyRoundModel(amazing, DerivPlayer);
            return Ok(amazing);
        }
        public ActionResult TimerFunction(float timestamp, string Phase, int Round)
        {
            TimerFunction timerFunction = new TimerFunction();
            return Ok(timerFunction.CheckTimerFunction(timestamp, Phase, Round, serverDataBase));
        }
        public ActionResult Privacy()
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

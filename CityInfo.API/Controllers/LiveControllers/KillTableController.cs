
using CityInfo.API.Models.BusinessObjects.DerivBO;
using CityInfo.API.Models.FilterModels;
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

        public KillTableController()
        {
            //_logger = logger;

            mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            mongoDatabase = mongoClient.GetDatabase("CSGSI-Nodes");

            serverDataBase = new ServerDataBase(mongoDatabase);
        }

        [HttpGet("hit")]
        public ActionResult test()
        {
            return Ok("is working");
        }

        //[HttpPost("killTable")]
        //public ActionResult postKillTable(string FirstHalf, string SecondHalf, string FullTime, string OT, string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total, int RoundX, int RoundY, float timestamp, string Phase, int Round)
        //{
        //    List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();

        //    ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

        //    KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(FirstHalf, SecondHalf, FullTime, OT, FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total, RoundX, RoundY, timestamp, Phase, Round, serverDataBase);


        //    return Ok(JsonConvert.SerializeObject(killTableModel));
        //}
        [HttpPost("killTable")]
        public ActionResult postKillTable()/*string FirstHalf, string SecondHalf, string FullTime, string OT, string FB, string HB, string Eco, string GunRound, string PartialGunRound, string GRAWP, string total, int RoundX, int RoundY, float timestamp, string Phase, int Round)*/
        {

            ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

            KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(serverDataBase);

            //KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(FirstHalf, SecondHalf, FullTime, OT, FB, HB, Eco, GunRound, PartialGunRound, GRAWP, total, RoundX, RoundY, timestamp, Phase, Round, serverDataBase);

            return Ok(JsonConvert.SerializeObject(killTableModel));
        }
        [HttpPost("economy")]
        public ActionResult economy()
        {
            EconomyTableServ economyTableServ = new EconomyTableServ();
            economyTableServ.SetEcononmyTable(serverDataBase);

            return Ok(JsonConvert.SerializeObject(economyTableServ.economyTable));
        }

        [HttpPost("counterexpansion")]
        public ActionResult CounterExpansionTable()
        {
            int totalRound = serverDataBase.GetTotalRoundCount();
            CounterExpansionServ counterExpansionServ = new CounterExpansionServ(totalRound);
            counterExpansionServ.CheckFiltersCounterExpansionTable(serverDataBase);
            return Ok(JsonConvert.SerializeObject((counterExpansionServ.counterExpansionModel)));
        }
        [HttpPost("engagement")]
        public ActionResult engagementPage()
        {
            CalcEngagmentServ calcEngagmentServ = new CalcEngagmentServ();
            calcEngagmentServ.Engagment(serverDataBase);
            List<Engagement> engagementList = new List<Engagement>();
            engagementList.Add(calcEngagmentServ.engagementCT);
            engagementList.Add(calcEngagmentServ.engagementT);

            return Ok(JsonConvert.SerializeObject(engagementList));
        }[HttpPost("engagementDetailed")]
        public ActionResult engagementDetailedTable()
        {
            DetailedEngagement detailedEngagement = new DetailedEngagement();
            detailedEngagement.Engagment(serverDataBase);

            return Ok(JsonConvert.SerializeObject(engagementList));
        }
        //[HttpPost("test")]
        //public ActionResult getTableFilters([FromBody] KillTableFilters killTableFilters)
        //{
        //    List<Deriv_PlayerTeam_BO> ListofRounds = new List<Deriv_PlayerTeam_BO>();

        //    ScoreBoardServ scoreBoardServ = new ScoreBoardServ();

        //    KillTableModel killTableModel = scoreBoardServ.CheckScoreBoardFilters(killTableFilters.FirstHalf, killTableFilters.SecondHalf,
        //        killTableFilters.FullTime, killTableFilters.OT, killTableFilters.FB, killTableFilters.HB, killTableFilters.Eco,
        //        killTableFilters.GunRound, killTableFilters.PartialGunRound, killTableFilters.GRAWP, killTableFilters.total,
        //        killTableFilters.RoundX, killTableFilters.RoundY, killTableFilters.timestamp, killTableFilters.Phase, killTableFilters.Round,
        //        serverDataBase);

        //    return Ok(killTableFilters.GunRound);
        //    return Ok(JsonConvert.SerializeObject(killTableModel));
        //}

        //[HttpGet("/counterexpansion")]
        //public ActionResult CounterExpansionTable(string FirstHalf, string SecondHalf, string FullTime, string OT)
        //{
        //    int totalRound = serverDataBase.GetTotalRoundCount();
        //    CounterExpansionServ counterExpansionServ = new CounterExpansionServ(FirstHalf, SecondHalf, FullTime, OT, totalRound);
        //    counterExpansionServ.CheckFiltersCounterExpansionTable(serverDataBase);
        //    return Ok(counterExpansionServ.counterExpansionModel);
        //}

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

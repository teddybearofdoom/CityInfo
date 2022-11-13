using CSGSI_FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using CSGO_GSI_Backend.Models.BusinessObjects.DerivBO;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System.Diagnostics;
using MongoDB.Bson;
using CityInfo.API.Services.DatabaseServ;
using CSGSI_FrontEnd.FrontEndServices.EngagmentServ;
using CSGSI_FrontEnd.ViewModels.Engagment_Models;
using Newtonsoft.Json;

namespace CSGSI_Engine.Controllers
{
    public class EngagementPageController : Controller
    {
        private readonly ILogger<EngagementPageController> _logger;
        private MongoClient mongoClient { get; set; }
        private IMongoDatabase mongoDatabase { get; set; }
        private ServerDataBase serverDataBase { get; set; }
        private string _configurationg { get; set; }
        private string _envName { get; set; }
        public EngagementPageController(ILogger<EngagementPageController> logger, string[] ConfigurationValue)
        {
            _logger = logger;

            //mongoClient = new MongoClient("mongodb://127.0.0.1:27017");
            mongoClient = new MongoClient(_configurationg);
            mongoDatabase = mongoClient.GetDatabase("astralis-vs-big-m1-dust");

            serverDataBase = new ServerDataBase(mongoDatabase);
        }

        [HttpGet]
        public ActionResult Index(string ctPlayers, string tPlayers)
        {
            CalcEngagmentServ calcEngagmentServ = new CalcEngagmentServ();
            if (ctPlayers != null && tPlayers != null)
            {
                calcEngagmentServ.EngagementWithFilters(serverDataBase,ctPlayers,tPlayers);
            }
            else
            {
                calcEngagmentServ.Engagment(serverDataBase);
            }         

            List<Engagement> engagementList = new List<Engagement>();
            engagementList.Add(calcEngagmentServ.engagementCT);
            engagementList.Add(calcEngagmentServ.engagementT);

            return Ok(JsonConvert.SerializeObject(engagementList));
        }
    }
}

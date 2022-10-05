using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [Route("api/killtable")]
    [ApiController]
    public class Historic_KillTableController : ControllerBase
    {
        [HttpPost]
        public ActionResult saveKillTable()
        {
            return Ok("Test save kill table endpoint");
        }
    }
}

﻿using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    [ApiController]
    [Route("api/cities")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.Current.Cities);
        }

        //instead of jsonresult we can use action result 
        //this provides with helper methods which we can use to set our status codes
        //and other important header details etc for easier processing of our request
        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCity(int id)
        {
            var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
            
        }
    }
}

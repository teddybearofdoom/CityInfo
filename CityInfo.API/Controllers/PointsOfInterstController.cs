using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers
{
    //variable in route surround curly braces need to match
    //parameters in methods

    //apicontroller handle bad requests on validation errors
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterstController : ControllerBase
    {
        private readonly ILogger<PointsOfInterstController> _logger;
        //After implementing interface on our mail service and telling
        //our service provide to implement the interface instead of 
        ///concreate class
        private readonly IMailService _mailService;
        private readonly CitiesDataStore _citiesDataStore;

        public PointsOfInterstController(ILogger<PointsOfInterstController> logger, IMailService mailService, CitiesDataStore citiesDataStore)
        {
            _citiesDataStore = citiesDataStore ?? throw new ArgumentNullException(nameof(citiesDataStore));

            _mailService = mailService ?? throw new ArgumentNullException(nameof(mailService)); 
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            try
            {
                //throw new Exception("Exception sample");
                var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

                if (city == null)
                {
                    _logger.LogInformation($"City with id {cityId} wasn't found when accessing points of interest");
                    return NotFound();
                }

                return Ok(city.PointOfInterests);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting points of interest for city with id {cityId}.", ex);
                return StatusCode(500, "A problem happened while handling your request");
            }
            
        }

        [HttpGet("{pointofinterestid}", Name = "GetPointOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterest = city.PointOfInterests.FirstOrDefault(c => c.Id == pointOfInterestId);

            if (pointOfInterest == null)
            {
                return NotFound();
            }

            return Ok(pointOfInterest);
        }

        //[FromBody] tag is unneccesary with ApiController Attributed on top of controller
        //it resolves complex types to come from body 
        //cityId is coming from our route defined on the controller 
        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, [FromBody]PointOfInterestForCreationDto pointOfInterest)
        {
            //ModelState is a dictionary containing both the state of the model (thats PointOfInterestForCreationDto) and
            //model binding validation
            //It represents a collection of name value pairs that were submitted to our API, one for each property
            //It also contains a collection of error messages for each value submitted
            //Whenever a request comes in the rules for our model are checked automatically
            //this below statement is not necessary with ApiController attribute
            if(!ModelState.IsValid)
            {
                return BadRequest(); 
            }

            //few things can go wrong with POST
            //trying to add a point of interest to a city that doesn't exist

            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound(); 
            }

            //if city is found
            //check for the max Id reached in the points of interest

            var maxPointOfInterestId = _citiesDataStore.Cities.SelectMany(
                c => c.PointOfInterests).Max(p => p.Id);

            //the point of interest we are getting from the body is of "PointOfInterestForCreationDto"
            //and our return result is of "PointOfInterestDto" hence we need to make sure that the object 
            //we send corresponds to correct type for deserialization

            //create new pointofInterestDto to be added
            var finalPointOfInterest = new PointOfInterestDto()
            {
                //add one to the max Id calc from city found from Id 
                Id = ++maxPointOfInterestId,

                //assign creation DTO's values to PointOfInterestDTO
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            //add to city point of interest
            city.PointOfInterests.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    cityId = cityId,
                    pointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest);

        }

        [HttpPut("{pointofinterestid}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId,
            PointsOfInterestForUpdateDto pointOfInterest)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound(); 
            }

            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(poi => poi.Id == pointOfInterestId);
            if(pointOfInterestFromStore == null)
            {
                return NotFound(); 
            }

            pointOfInterestFromStore.Name = pointOfInterest.Name;
            pointOfInterestFromStore.Description = pointOfInterest.Description;

            return NoContent();
        }

        [HttpPatch("{pointofinterestid}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestId,
            JsonPatchDocument<PointsOfInterestForUpdateDto> patchDocument)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if(city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(c => c.Id == pointOfInterestId);
            if(pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            //we are return update dto, however, when getting the pointofinterest using ID
            //we are using the pointofinterestdto
            //we won't be able to patch b/c of different classes therefore we map the fromstoredto 
            //to a update dto
            var pointOfInterestToPatch = new PointsOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description,
            };

            //then we patch the said object using the patchdocument passed in body
            //ModelState is passed to make sure valid concerns were passed and if not that it fails 
            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }

        [HttpDelete("{pointOfInterestId}")]
        public ActionResult DeletePointOfInterest(int cityId, int pointOfInterestId)
        {
            var city = _citiesDataStore.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(c => c.Id == pointOfInterestId);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }

            city.PointOfInterests.Remove(pointOfInterestFromStore);
            _mailService.Send(
                "Point of interest deleted. ",
                $"Point of interest {pointOfInterestFromStore.Name} with id {pointOfInterestFromStore.Id} was deleted.");
            return NoContent();
        }
    }
}

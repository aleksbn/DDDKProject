using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LocationController> _logger;
        private readonly IMapper _mapper;

        public LocationController(IUnitOfWork unitOfWork, ILogger<LocationController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionName(nameof(GetLocations))]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var locations = await _unitOfWork.Locations.GetAll();
                var locationsToReturn = _mapper.Map<IList<LocationDTO>>(locations);
                return Ok(locationsToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(LocationController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpGet("{id:int}")]
        [ActionName(nameof(GetLocation))]
        public async Task<IActionResult> GetLocation(int id)
        {
            try
            {
                var location = await _unitOfWork.Locations.Get(l => l.Id == id, new List<string>
                {
                    "DonationEvents"
                });
                var locationToReturn = _mapper.Map<LocationDTO>(location);
                return Ok(locationToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(LocationController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpPost]
        [ActionName(nameof(CreateLocation))]
        public async Task<IActionResult> CreateLocation([FromBody]CreateLocationDTO locationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateLocation)}");
                return BadRequest(ModelState);
            }

            try
            {
                var location = _mapper.Map<Location>(locationDTO);
                await _unitOfWork.Locations.Insert(location);
                await _unitOfWork.Save();
                return CreatedAtAction(nameof(GetLocation), new { id = location.Id }, location);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(CreateLocation)}.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpPut]
        [ActionName(nameof(UpdateLocation))]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] UpdateLocationDTO locationDTO)
        {
            if (!ModelState.IsValid || id < 1) 
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateLocation)}");
                return BadRequest(ModelState);
            }

            try
            {
                var location = await _unitOfWork.Locations.Get(q => q.Id == id);
                if (location == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateLocation)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(locationDTO, location);
                _unitOfWork.Locations.Update(location);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Somethoing went wrong in the {nameof(UpdateLocation)}");
                return StatusCode(500, "Internal server error, please try later");
            }
        }
    }
}

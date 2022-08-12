using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
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
    }
}

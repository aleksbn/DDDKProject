using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [ActionName(nameof(GetLocations))]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _unitOfWork.Locations.GetAll();
            var locationsToReturn = _mapper.Map<IList<LocationDTO>>(locations);
            return Ok(locationsToReturn);
        }

        [HttpPost]
        [ActionName(nameof(CreateLocation))]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationDTO locationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateLocation)}");
                return BadRequest(ModelState);
            }
            var location = _mapper.Map<Location>(locationDTO);
            await _unitOfWork.Locations.Insert(location);
            await _unitOfWork.Save();
            return Ok("Object has been created");
        }

        [HttpPut("{id:int}")]
        [ActionName(nameof(UpdateLocation))]
        public async Task<IActionResult> UpdateLocation(int id, [FromBody] UpdateLocationDTO locationDTO)
        {
            if (!ModelState.IsValid || id < 1) 
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateLocation)}");
                return BadRequest(ModelState);
            }
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

        [HttpDelete("{id:int}")]
        [ActionName(nameof(DeleteLocation))]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (id < 1)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(UpdateLocation)}");
                return BadRequest("That location does not exist");
            }
            var location = await _unitOfWork.Locations.Get(q => q.Id == id);
            if (location == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(UpdateLocation)}");
                return BadRequest("Submitted data is invalid");
            }
            await _unitOfWork.Locations.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}

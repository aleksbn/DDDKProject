using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DonatorController> _logger;
        private readonly IMapper _mapper;

        public DonatorController(IUnitOfWork unitOfWork, ILogger<DonatorController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var donator = await _unitOfWork.Donators.Get(d => d.ID == id, new List<string>
                {
                    "Donations"
                });
                var donatorToReturn = _mapper.Map<DonatorDTO>(donator);
                return Ok(donatorToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonatorController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpGet(Name = "ofonebloodtype")]
        public async Task<IActionResult> GetAllFromBloodType(int bloodTypeId)
        {
            try
            {
                var donators = await _unitOfWork.Donators.GetAll(d => d.BloodTypeId == bloodTypeId, null, new List<string>
                {
                   "BloodType", "Donations"
                });
                var donatorsToReturn = _mapper.Map<IList<DonatorDTO>>(donators);
                return Ok(donatorsToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonatorController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }
    }
}

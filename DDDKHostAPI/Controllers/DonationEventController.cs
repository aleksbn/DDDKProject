using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonationEventController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DonationEventController> _logger;
        private readonly IMapper _mapper;

        public DonationEventController(IUnitOfWork unitOfWork, ILogger<DonationEventController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var donationEvents = await _unitOfWork.DonationEvents.GetAll(null, null, new List<string>
                {
                    "Location"
                });
                var donationEventsToReturn = _mapper.Map<IList<DonationEventDTO>>(donationEvents);
                return Ok(donationEventsToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonationEventController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var donationEvents = await _unitOfWork.DonationEvents.GetAll(de => de.Id == id, null, new List<string>
                {
                    "Location"
                });
                var donationEventsToReturn = _mapper.Map<IList<DonationEventDTO>>(donationEvents);
                return Ok(donationEventsToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonationEventController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }
    }
}

using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Authorize]
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
        [ActionName(nameof(GetAll))]
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
        [ActionName(nameof(Get))]
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

        [HttpPost]
        [ActionName(nameof(CreateDonationEvent))]
        public async Task<IActionResult> CreateDonationEvent([FromBody] CreateDonationEventDTO donationEventDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateDonationEvent)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donationEvent = _mapper.Map<DonationEvent>(donationEventDTO);
                await _unitOfWork.DonationEvents.Insert(donationEvent);
                await _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = donationEvent.Id }, donationEvent);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Something went wrong in the {nameof(CreateDonationEvent)}");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpPut]
        [ActionName(nameof(UpdateDonationEvent))]
        public async Task<IActionResult> UpdateDonationEvent(int id, [FromBody] UpdateDonationEventDTO donationEventDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonationEvent)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donationEvent = await _unitOfWork.DonationEvents.Get(q => q.Id == id);
                if (donationEvent == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonationEvent)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(donationEventDTO, donationEvent);
                _unitOfWork.DonationEvents.Update(donationEvent);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Somethoing went wrong in the {nameof(UpdateDonationEvent)}");
                return StatusCode(500, "Internal server error, please try later");
            }
        }
    }
}

using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace DDDKHostAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DonationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DonationController> _logger;
        private readonly IMapper _mapper;

        public DonationController(IUnitOfWork unitOfWork, ILogger<DonationController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("donator")]
        [ActionName(nameof(GetAllFromDonator))]
        public async Task<IActionResult> GetAllFromDonator(int donatorId)
        {
            try
            {
                var donations = await _unitOfWork.Donations.GetAll(d => d.DonatorId == donatorId, null, new List<string>
                {
                    "DonationEvent"
                });
                var donationsToReturn = _mapper.Map<IList<DonationDTO>>(donations);
                return Ok(donationsToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonationController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpGet]
        [Route("donation")]
        [ActionName(nameof(Get))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var donation = await _unitOfWork.Donations.Get(d => d.Id == id);
                var donationToReturn = _mapper.Map<DonationDTO>(donation);
                return Ok(donationToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonationController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpGet]
        [Route("event")]
        [ActionName(nameof(GetAllFromDonationEvent))]
        public async Task<IActionResult> GetAllFromDonationEvent(int donationEventId)
        {
            try
            {
                var donations = await _unitOfWork.Donations.GetAll(d => d.DonationEventId == donationEventId, null, new List<string>
                {
                    "Donator"
                });
                var donationsToReturn = _mapper.Map<IList<DonationDTO>>(donations);
                return Ok(donationsToReturn);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(DonationController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpPost]
        [ActionName(nameof(CreateDonation))]
        public async Task<IActionResult> CreateDonation([FromBody] CreateDonationDTO donationDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateDonation)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donation = _mapper.Map<Donation>(donationDTO);
                await _unitOfWork.Donations.Insert(donation);
                await _unitOfWork.Save();
                return CreatedAtAction(nameof(Get), new { id = donation.Id }, donation);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Something went wrong in the {nameof(CreateDonation)}");
                return StatusCode(500, "Internal server error, try again");
            }
        }

        [HttpPut]
        [ActionName(nameof(UpdateDonation))]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] UpdateDonationDTO donationDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonation)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donation = await _unitOfWork.Donations.Get(q => q.Id == id);
                if (donation == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonation)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(donationDTO, donation);
                _unitOfWork.Donations.Update(donation);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Somethoing went wrong in the {nameof(UpdateDonation)}");
                return StatusCode(500, "Internal server error, please try later");
            }
        }
    }
}

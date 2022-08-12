using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
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

        [HttpGet("{donatorId:int}")]
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

        [HttpGet("{donationEventId:int}")]
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
    }
}

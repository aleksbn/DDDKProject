using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

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

        [HttpGet]
        [ActionName(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var donations = await _unitOfWork.Donations.GetAll(null, donations => donations.OrderBy(d => d.Donator.LastName).ThenBy(d => d.Donator.FirstName).ThenBy(d => d.DonationEvent.EventDate), new List<string>
            {
                "Donator"
            });
            var donationsToReturn = _mapper.Map<IList<DonationDTO>>(donations);
            foreach (var donation in donationsToReturn)
            {
                var donator = await _unitOfWork.Donators.Get(d => d.Id == donation.DonatorId);
                if(donation.DonationEventId != 0)
                {
                    DonationEvent donationEvent = await _unitOfWork.DonationEvents.Get(d => d.Id == donation.DonationEventId);
                    donation.DonatorFullName = donator.FirstName + " " + donator.LastName + "(" + donator.Id + ") - " + donationEvent.EventDate.ToString("dd.MM.yyyy");
                }
                else
                {
                    donation.DonatorFullName = donator.FirstName + " " + donator.LastName + " - Unknown date";
                }
            }
            return Ok(donationsToReturn);
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
            var donation = _mapper.Map<Donation>(donationDTO);
            if ((await _unitOfWork.Donations.GetAll()).Any(d => d.DonatorId == donation.DonatorId && d.DonationEventId == donation.DonationEventId))
            {
                return BadRequest("That donator has already donated blood on that donation event!");
            }
            await _unitOfWork.Donations.Insert(donation);
            await _unitOfWork.Save();
            return Ok(donation.Id);
        }

        [HttpPut("{id:int}")]
        [ActionName(nameof(UpdateDonation))]
        public async Task<IActionResult> UpdateDonation(int id, [FromBody] UpdateDonationDTO donationDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonation)}");
                return BadRequest(ModelState);
            }
            var donation = await _unitOfWork.Donations.Get(q => q.Id == id);
            if (donation == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonation)}");
                return BadRequest("Submitted data is invalid");
            }
            _mapper.Map(donationDTO, donation);
            donation.Id = id;
            if ((await _unitOfWork.Donations.GetAll()).Any(d => d.DonatorId == donation.DonatorId && d.DonationEventId == donation.DonationEventId))
            {
                return BadRequest("That donator has already donated blood on that donation event!");
            }
            _unitOfWork.Donations.Update(donation);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ActionName(nameof(DeleteDonation))]
        public async Task<IActionResult> DeleteDonation(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonation)}");
                return BadRequest();
            }
            var donation = await _unitOfWork.Donations.Get(de => de.Id == id);
            if (donation == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonation)}");
                return BadRequest("Submitted data is invalid");
            }
            await _unitOfWork.Donations.Delete(donation.Id);
            await _unitOfWork.Save();
            return Ok("Donation deleted!");
        }
    }
}

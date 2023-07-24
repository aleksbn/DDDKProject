using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        [ActionName(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var donationEvents = await _unitOfWork.DonationEvents.GetAll(null, donationEvents => donationEvents.OrderBy(de => de.Location.Name), new List<string>
            {
                "Location"
            });
            var donationEventsToReturn = _mapper.Map<IList<DonationEventDTO>>(donationEvents);
            return Ok(donationEventsToReturn);
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
            var donationEvent = _mapper.Map<DonationEvent>(donationEventDTO);
            await _unitOfWork.DonationEvents.Insert(donationEvent);
            await _unitOfWork.Save();
            return Ok("Object has been created");
        }

        [HttpPut("{id:int}")]
        [ActionName(nameof(UpdateDonationEvent))]
        public async Task<IActionResult> UpdateDonationEvent(int id, [FromBody] UpdateDonationEventDTO donationEventDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonationEvent)}");
                return BadRequest(ModelState);
            }
            var donationEvent = await _unitOfWork.DonationEvents.Get(q => q.Id == id);
            if (donationEvent == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonationEvent)}");
                return BadRequest("Submitted data is invalid");
            }
            _mapper.Map(donationEventDTO, donationEvent);
            donationEvent.Location = null;
            _unitOfWork.DonationEvents.Update(donationEvent);
            await _unitOfWork.Save();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ActionName(nameof(DeleteDonationEvent))]
        public async Task<IActionResult> DeleteDonationEvent(int id)
        {
            if(id <= 0)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonationEvent)}");
                return BadRequest();
            }
            var donationEvent = await _unitOfWork.DonationEvents.Get(de => de.Id ==  id);
            if (donationEvent == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonationEvent)}");
                return BadRequest("Submitted data is invalid");
            }
            var donationsToUpdate = await _unitOfWork.Donations.GetAll(d => d.DonationEventId == id);
            if (donationsToUpdate.Count > 0)
            {
                foreach (var donation in donationsToUpdate)
                {
                    donation.DonationEventId = 0;
                    _unitOfWork.Donations.Update(donation);
                    await _unitOfWork.Save();
                }
            }
            await _unitOfWork.DonationEvents.Delete(donationEvent.Id);
            await _unitOfWork.Save();
            return Ok("Donation event deleted!");
        }
    }
}

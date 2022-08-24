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
        [ActionName(nameof(GetDonator))]
        public async Task<IActionResult> GetDonator(int id)
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

        [HttpGet]
        [Route("bloodtype")]
        [ActionName(nameof(GetAllFromBloodType))]
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

        [HttpPost]
        [ActionName(nameof(CreateDonator))]
        public async Task<IActionResult> CreateDonator([FromBody] CreateDonatorDTO donatorDTO)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateDonator)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donator = _mapper.Map<Donator>(donatorDTO);
                await _unitOfWork.Donators.Insert(donator);
                await _unitOfWork.Save();
                return CreatedAtAction(nameof(GetDonator), new { id = donator.ID }, donator);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(CreateDonator)}.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }

        [HttpPut]
        [ActionName(nameof(UpdateDonator))]
        public async Task<IActionResult> UpdateDonator(int id, [FromBody] UpdateDonatorDTO donatorDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonator)}");
                return BadRequest(ModelState);
            }

            try
            {
                var donator = await _unitOfWork.Donators.Get(q => q.ID == id);
                if (donator == null)
                {
                    _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonator)}");
                    return BadRequest("Submitted data is invalid");
                }
                _mapper.Map(donatorDTO, donator);
                _unitOfWork.Donators.Update(donator);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Somethoing went wrong in the {nameof(UpdateDonator)}");
                return StatusCode(500, "Internal server error, please try later");
            }
        }

        [HttpDelete("{id:int}")]
        [ActionName(nameof(DeleteDonator))]
        public async Task<IActionResult> DeleteDonator(int id)
        {
            if (id <= 0)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonator)}");
                return BadRequest();
            }

            try
            {
                var donator = await _unitOfWork.Donators.Get(q => q.ID == id);
                if (donator == null)
                {
                    _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonator)}");
                    return BadRequest("Submitted data is invalid");
                }
                await _unitOfWork.Donators.Delete(id);
                await _unitOfWork.Save();
                return NoContent();
            }
            catch (Exception x)
            {
                _logger.LogError(x, $"Something Went Wrong in the {nameof(DeleteDonator)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }
        }
    }
}

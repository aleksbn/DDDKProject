using AutoMapper;
using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using DDDKHostAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
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
        //3.1.5 Dodajemo AutoMapper kako bismo podatke preuzete u domenskoj klasi mogli da pretvorimo u DTO klasu
        private readonly IMapper _mapper;

        public DonatorController(IUnitOfWork unitOfWork, ILogger<DonatorController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ActionName(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var donators = await _unitOfWork.Donators.GetAll(null, donators => donators.OrderBy(d => d.LastName).ThenBy(d => d.FirstName));
            var donatorsToReturn = _mapper.Map<List<DonatorDTO>>(donators);
            return Ok(donatorsToReturn);
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
            var donator = _mapper.Map<Donator>(donatorDTO);
            await _unitOfWork.Donators.Insert(donator);
            await _unitOfWork.Save();
            return Ok(donator.Id);
        }

        [HttpPut("{id:int}")]
        [ActionName(nameof(UpdateDonator))]
        public async Task<IActionResult> UpdateDonator(int id, [FromBody] UpdateDonatorDTO donatorDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonator)}");
                return BadRequest(ModelState);
            }
            var donator = await _unitOfWork.Donators.Get(q => q.Id == id);
            if (donator == null)
            {
                _logger.LogError($"Invalid UPDATE attempt in {nameof(UpdateDonator)}");
                return BadRequest("Submitted data is invalid");
            }
            donatorDTO.Id = id;
            _mapper.Map(donatorDTO, donator);
            _unitOfWork.Donators.Update(donator);
            await _unitOfWork.Save();
            return NoContent();
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
            var donator = await _unitOfWork.Donators.Get(q => q.Id == id);
            if (donator == null)
            {
                _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteDonator)}");
                return BadRequest("Submitted data is invalid");
            }
            await _unitOfWork.Donators.Delete(id);
            await _unitOfWork.Save();
            return NoContent();
        }
    }
}

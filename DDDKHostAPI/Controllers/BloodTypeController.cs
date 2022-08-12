using DDDKHostAPI.IRepository;
using DDDKHostAPI.Models.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BloodTypeController> _logger;

        public BloodTypeController(IUnitOfWork unitOfWork, ILogger<BloodTypeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var bloodTypes = await _unitOfWork.BloodTypes.GetAll();
                return Ok(bloodTypes);
            }
            catch (Exception x)
            {
                _logger.LogError(x, $" Something went wrong in the {nameof(BloodTypeController)} controller.");
                return StatusCode(500, "Internal server error, please try again");
            }
        }
    }
}

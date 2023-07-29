using DDDKHostAPI.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDKHostAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
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
            var bloodTypes = await _unitOfWork.BloodTypes.GetAll();
            return Ok(bloodTypes);
        }
    }
}

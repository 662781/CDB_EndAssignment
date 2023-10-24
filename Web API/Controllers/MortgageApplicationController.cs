using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web_API.Controllers
{
    [Route("api/Application")]
    [ApiController]
    public class MortgageApplicationController : ControllerBase
    {

        private readonly MortgageApplicationService _service;
        public MortgageApplicationController(MortgageApplicationService service)
        {
            _service = service;
        }

        [HttpGet("GetAllByBuyerId")]
        public IActionResult GetAllByBuyerId([FromQuery] int id)
        {
            List <MortgageApplication> applications = _service.GetAllByBuyerId(id);

            return applications.Count == 0 ? NotFound() : Ok(applications);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            MortgageApplication application = _service.GetById(id);
            return application == null ? NotFound() : Ok(application);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateApplicationDTO newApplication)
        {
            if (newApplication == null)
            {
                return BadRequest("Invalid data in the request body");
            }

            _service.Create(newApplication);

            return CreatedAtAction("GetById", new { id = newApplication.ID }, newApplication);
        }
    }
}

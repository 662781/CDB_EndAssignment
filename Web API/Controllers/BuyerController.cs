using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase, IBuyerController
    {
        private readonly BuyerService _buyerService;
        public BuyerController(BuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            Buyer buyer = _buyerService.GetById(id);

            if (buyer == null)
            {
                return NotFound();
            }

            return Ok(buyer);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Buyer newBuyer)
        {
            if (newBuyer == null)
            {
                return BadRequest("Invalid data in the request body");
            }

            _buyerService.Create(newBuyer);

            return CreatedAtAction("GetById", new { id = newBuyer.ID }, newBuyer);
        }
    }
}

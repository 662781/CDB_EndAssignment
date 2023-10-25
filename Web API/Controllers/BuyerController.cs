using Domain;
using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Interfaces;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase, IBuyerController
    {
        private readonly IBuyerService _buyerService;
        public BuyerController(BuyerService buyerService)
        {
            _buyerService = buyerService;
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            Buyer buyer = _buyerService.GetById(id);
            return buyer == null ? NotFound() : Ok(buyer);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateBuyerDTO buyerDTO)
        {
            if (buyerDTO == null)
            {
                return BadRequest("Invalid data in the request body");
            }

            Buyer newBuyer = _buyerService.Create(buyerDTO);

            return CreatedAtAction("GetById", new { id = newBuyer.ID }, newBuyer);
        }
    }
}

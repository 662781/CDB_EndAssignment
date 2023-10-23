using Service;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly HouseService _houseService;
        public HouseController(HouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet("GetByPriceRange")]
        public IActionResult GetByPriceRange([FromQuery] float minPrice, [FromQuery] float maxPrice)
        {
            return Ok(_houseService.GetByPriceRange(minPrice, maxPrice));
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            House house = _houseService.GetById(id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] House newHouse)
        {
            if (newHouse == null)
            {
                return BadRequest("Invalid data in the request body");
            }

            _houseService.Create(newHouse);

            return CreatedAtAction("GetById", new { id = newHouse.ID }, newHouse);
        }

    }
}
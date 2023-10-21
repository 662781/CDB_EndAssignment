using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly BuyersContext _db;
        public HouseController(BuyersContext buyersContext)
        {
            _db = buyersContext;
        }

        [HttpGet("GetByPriceRange")]
        public IActionResult GetHousesByPriceRange([FromQuery] float minPrice, [FromQuery] float maxPrice)
        {
            var houses = _db.Houses
                .Where(h => h.Price >= minPrice && h.Price <= maxPrice)
                .ToList();

            return Ok(houses);
        }

        [HttpGet("GetHouseById/{id}")]
        public IActionResult GetHouseById(int id)
        {
            var house = _db.Houses.FirstOrDefault(h => h.ID == id);

            if (house == null)
            {
                return NotFound();
            }

            return Ok(house);
        }

        [HttpPost("CreateHouse")]
        public IActionResult CreateHouse([FromBody] House newHouse)
        {
            if (newHouse == null)
            {
                return BadRequest("Invalid data in the request body");
            }

            _db.Houses.Add(newHouse);
            _db.SaveChanges();

            return CreatedAtAction("GetHouseById", new { id = newHouse.ID }, newHouse);
        }

    }
}
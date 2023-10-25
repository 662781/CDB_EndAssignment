using Service;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Domain.DTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseController : ControllerBase
    {
        private readonly IHouseService _houseService;
        public HouseController(HouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet("GetByPriceRange")]
        public IActionResult GetByPriceRange([FromQuery] float minPrice, [FromQuery] float maxPrice)
        {
            List<House> houses = _houseService.GetByPriceRange(minPrice, maxPrice);
            return houses.Count == 0 ? NotFound() : Ok(houses);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            House house = _houseService.GetById(id);
            return house == null ? NotFound() : Ok(house);
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CreateHouseDTO houseDTO)
        {
            if (houseDTO == null)
            {
                return BadRequest("Invalid data in the request body");
            }

            House newHouse = _houseService.Create(houseDTO);

            return CreatedAtAction("GetById", new { id = newHouse.ID }, newHouse);
        }

    }
}
using Service;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public interface IHouseController
    {
        public IActionResult GetByPriceRange([FromQuery] float minPrice, [FromQuery] float maxPrice);

        public IActionResult GetById(int id);

        public IActionResult Create([FromBody] House newHouse);

    }
}
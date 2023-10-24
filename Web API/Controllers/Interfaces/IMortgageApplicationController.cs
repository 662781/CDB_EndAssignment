using Domain;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web_API.Controllers
{
    public interface IMortgageApplicationController
    {
        public IActionResult GetAllByBuyerId([FromQuery] int id);
        public IActionResult GetById(int id);
        public IActionResult Create([FromBody] MortgageApplication newApplication);
    }
}

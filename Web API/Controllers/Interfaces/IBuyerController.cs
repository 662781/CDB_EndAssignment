using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Web_API.Controllers
{
    public interface IBuyerController
    {
        public IActionResult GetById(int id);
        public IActionResult Create([FromBody] Buyer newBuyer);
    }
}

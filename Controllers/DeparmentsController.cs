using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WorldDominion
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Id", 1 }, { "Name", "Fruits and Vegetables" } },
                new Dictionary<string, object> { { "Id", 2 }, { "Name", "Meats" } },
                new Dictionary<string, object> { { "Id", 3 }, { "Name", "Sweets and Treats" } },
            };

            return View(data);
        }
    }
}

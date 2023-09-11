using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WorldDominion
{
    public class DepartmentsController : Controller
    {
        // A simple dictionary of some data
        private List<Dictionary<string, object>> _data = new List<Dictionary<string, object>>
        {
            new Dictionary<string, object> { { "Id", 1 }, { "Name", "Fruits and Vegetables" } },
            new Dictionary<string, object> { { "Id", 2 }, { "Name", "Meats" } },
            new Dictionary<string, object> { { "Id", 3 }, { "Name", "Sweets and Treats" } },
        };

        public IActionResult Index()
        {
            return View(_data);
        }
    }
}

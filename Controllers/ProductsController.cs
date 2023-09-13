using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WorldDominion
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            List<Dictionary<string, object>> data = new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Id", 1 }, { "DepartmentId", 1 }, { "Name", "Watermelon" } },
                new Dictionary<string, object> { { "Id", 2 }, { "DepartmentId", 1 }, { "Name", "Cantaloupe" } },
                new Dictionary<string, object> { { "Id", 3 }, { "DepartmentId", 1 }, { "Name", "Strawberries" } },
            };

            return View(data);
        }
    }
}
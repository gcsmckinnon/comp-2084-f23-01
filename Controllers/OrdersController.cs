using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorldDominion.Models;
using WorldDominion.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace WorldDominion.Controllers
{
    public class OrdersController : Controller
    {
        private readonly CartService _cartService;
        private readonly ApplicationDbContext _context;

        public OrdersController(CartService cartService, ApplicationDbContext context)
        {
            _cartService = cartService;
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Order.Include(o => o.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var order = await _context.Order
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [Authorize()]
        public async Task<IActionResult> Checkout()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = _cartService.GetCart();

            if (cart == null) {
                return NotFound();
            }

            var order = await _context.Order
                .FirstOrDefaultAsync(o => o.Id == cart.OrderId);

            order ??= new Order {
                UserId = userId
            };

            var orderItems = new List<OrderItem>();

            foreach(var cartItem in cart.CartItems)
            {
                var orderItem = new OrderItem {
                    OrderId = order.Id,
                    ProductName = cartItem.Product.Name,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Product.MSRP
                };

                orderItems.Add(orderItem);
            }

            order.OrderItems = orderItems;
            order.Total = cart.CartItems.Sum(cartItem => (decimal)(cartItem.Quantity * cartItem.Product.MSRP)); 

            return View("Details", order);
        }
    }
}

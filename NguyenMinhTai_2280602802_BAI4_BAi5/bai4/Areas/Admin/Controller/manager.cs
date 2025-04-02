using bai4.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace bai4.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display the list of orders
        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(o => o.ApplicationUser) // Include user information
                .Include(o => o.OrderDetails) // Include order details
                    .ThenInclude(od => od.Product) // Include product information in order details
                .ToListAsync();

            return View(orders);
        }

        // Action to display order details
        public async Task<IActionResult> Detail(int id)
        {
            var order = await _context.Orders
                .Include(o => o.ApplicationUser) // Include user information
                .Include(o => o.OrderDetails) // Include order details
                    .ThenInclude(od => od.Product) // Include product information in order details
                .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
    }
}


using DMStorefront.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DMStorefront.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using DMStorefront.Server.Models;

namespace DMStorefront.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public InventoryController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }

        [HttpGet("{userName}")]

        public async Task<IActionResult> Get(string userName)
        {
            Inventory? inventory = await _context.Inventories.FirstOrDefaultAsync(a => a.UserName == userName);
            if (inventory == null) return NotFound();
            else return Ok(inventory);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Inventory inventory)
        {
            _context.Entry(inventory).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}

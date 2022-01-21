using DMStorefront.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DMStorefront.Shared;
using Microsoft.EntityFrameworkCore;

namespace DMStorefront.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ItemController(ApplicationDbContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _context.Items.ToListAsync();
            return Ok(items);
        }
    }
}
  

using DMStorefront.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DMStorefront.Shared.Models;
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

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var item = await _context.Items.FirstOrDefaultAsync(a => a.Name == name);
            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Item item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return Ok(item.Name);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var item = new Item { Name = name };
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
  

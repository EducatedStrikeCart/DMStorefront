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
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> userManager;
        public StockController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return Ok(stocks);
        }

        [HttpGet("{userName}")]
        
        public async Task<IActionResult> Get(string userName)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(a => a.UserName == userName);
            await _context.Stocks.Include("Items").ToListAsync();
                foreach (Item item in stock.Items)
            {
                item.Stocks = null;
            }
            return Ok(stock.Items);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Stock stock)
        {
            _context.Add(stock);
            await _context.SaveChangesAsync();
            return Ok(stock.Id);
        }

        [HttpPost("{userName}/additem/{itemName}")]

        public async Task<IActionResult> Post(string itemName, string userName)
        {
           var newStock = await _context.Stocks.FirstOrDefaultAsync(a => a.UserName == userName);
            var newItem = await _context.Items.FirstOrDefaultAsync(a => a.Name == itemName);
            newStock.Items.Add(newItem);
            await _context.SaveChangesAsync();
            return Ok();
        }



        [HttpPut]
        public async Task<IActionResult> Put(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stock = new Stock { Id = id };
            _context.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


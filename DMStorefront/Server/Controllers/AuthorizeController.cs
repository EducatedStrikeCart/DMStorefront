using DMStorefront.Server.Data;
using DMStorefront.Server.Models;
using DMStorefront.Shared;
using DMStorefront.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DMStorefront.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginParameters parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.UserName);
            if (user == null) return BadRequest("User does not exist");
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, parameters.Password, false);
            if (!singInResult.Succeeded) return BadRequest("Invalid password");
            var stockStatus = await _context.Stocks.FirstOrDefaultAsync(s => s.UserName == user.UserName);
            if (stockStatus == null)
            {
                Stock userStock = new Stock();
                userStock.UserName = user.UserName;
                _context.Add(userStock);
                await _context.SaveChangesAsync();
            }
            await _signInManager.SignInAsync(user, parameters.RememberMe);

            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterParameters parameters)
        {
            var user = new ApplicationUser();
            user.UserName = parameters.UserName;
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.FirstOrDefault()?.Description);
            Inventory newInventory = new Inventory(0, user.UserName);
            _context.Add(newInventory);
            await _context.SaveChangesAsync();

            return await Login(new LoginParameters
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(UpdateAccountParameters parameters)
        {
            var user = await _userManager.FindByNameAsync(parameters.UserName);
            if (user == null) return BadRequest("User does not exist");
            else
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, parameters.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    await _context.SaveChangesAsync();
                    return Ok("Password change sucessful.");
                }
                else
                {
                    return BadRequest(result.Errors.FirstOrDefault()?.Description);
                }
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }

        [HttpGet]
        public UserInfo UserInfo()
        {
            //var user = await _userManager.GetUserAsync(HttpContext.User);
            return BuildUserInfo();
        }


        private UserInfo BuildUserInfo()
        {
            return new UserInfo
            {
                IsAuthenticated = User.Identity.IsAuthenticated,
                UserName = User.Identity.Name,
                ExposedClaims = User.Claims
                    //Optionally: filter the claims you want to expose to the client
                    //.Where(c => c.Type == "test-claim")
                    .ToDictionary(c => c.Type, c => c.Value)
            };
        }
    }
}

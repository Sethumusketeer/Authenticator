using Authenticator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly DynamicDbContext _context;

        public LoginController(DynamicDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginData user)
        {
            var users = await _context.WeatherUser.FirstOrDefaultAsync(x => x.UserId == user.UserId && x.Password == user.Password);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }
    }
}

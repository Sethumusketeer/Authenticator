using Authenticator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : Controller
    {
        private readonly DynamicDbContext _context;

        public RegisterController(DynamicDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<WeatherUser>> Register(RegisterModel registerModel)
        {
            var existingUser = await _context.WeatherUser.FirstOrDefaultAsync(user => user.Email == registerModel.Email);
            if (existingUser != null)
            {
                return BadRequest("Email already exists");
            }

            var userdeatils = new WeatherUser
            {
                Name = registerModel.Name,
                Email = registerModel.Email,
                Password = registerModel.Password
            };

            _context.WeatherUser.Add(userdeatils);
            _context.SaveChanges();

            var User = await _context.WeatherUser.FirstOrDefaultAsync(user => user.Email == registerModel.Email);

            return Ok(User);
        }

        [HttpPut("updatePassword")]
        public async Task<ActionResult<WeatherUser>> UpdatePassword(RegisterModel registerModel)
        {
            var existingUser = await _context.WeatherUser.FirstOrDefaultAsync(user => user.Email == registerModel.Email);
            if (existingUser == null)
            {
                return BadRequest("Update Password Failed - User not found");
            }

            existingUser.Password = registerModel.Password;
            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Update Password Failed - Data mismatch");
            }
            return Ok(existingUser);
        }

        [HttpPut("updateUserDetails")]
        public async Task<ActionResult<WeatherUser>> UpdateUserDetails(RegisterModel registerModel)
        {
            var existingUser = await _context.WeatherUser.FirstOrDefaultAsync(user => user.Email == registerModel.Email);
            if (existingUser == null)
            {
                return BadRequest("Update User Details Failed - User not found");
            }

            existingUser.Name = registerModel.Name;
            existingUser.Email = registerModel.Email;
            _context.Entry(existingUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Update User Details Failed - Data mismatch");
            }
            return Ok(existingUser);
        }
    }
}

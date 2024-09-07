using Authenticator.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Azure.Core.HttpHeader;

namespace Authenticator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : Controller
    {
        private readonly DynamicDbContext _context;

        public NotesController(DynamicDbContext context)
        {
            _context = context;
        }

        [HttpPost("createNote")]
        public IEnumerable<Notes> UpdateUserDetails(NotesResponse notes)
        {
            var userNotes = new Notes
            {
                UserId = notes.UserId,
                Content = notes.Content,
            };

            _context.Notes.Add(userNotes);
            _context.SaveChanges();

            var UserNotes = _context.Notes.Where(user => user.UserId == notes.UserId).ToArray();

            return UserNotes;
        }

        [HttpGet("getNotes/{userId}")]
        public async Task<ActionResult<Notes[]>> UpdateUserDetails(int userId)
        {
            var UserNotes = await _context.Notes.Where(user => user.UserId == userId).ToArrayAsync();

            if(!UserNotes.Any())
            {
                return new Notes[0];
            }

            return Ok(UserNotes);
        }

        [HttpPut("updateNote")]
        public async Task<ActionResult<Notes>> updateNote(Notes notes)
        {
            var existingRecord = _context.Notes.FirstOrDefault(x => x.RecordId == notes.RecordId);

            if(existingRecord == null)
            {
                return BadRequest("Record ID NotFound");
            }

            existingRecord.Content = notes.Content;
            _context.Entry(existingRecord).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Update Password Failed - Data mismatch");
            }
            return Ok(existingRecord);
        }

        [HttpDelete("deleteNote/{recordId}")]
        public async Task<IActionResult> DeleteNote(int recordId)
        {
            var userNotes = _context.Notes.FirstOrDefault(user => user.RecordId == recordId);

            if (userNotes == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(userNotes);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}

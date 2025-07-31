using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteManeger.Data;
using NoteManeger.Models;

namespace NoteManeger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly AppDbContext _context;
        public NoteController(AppDbContext context) =>
            _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get() => _context.TableNote1.ToList();

        [HttpPost]
        public IActionResult Post(Note note)
        {
            note.CreatedAt = DateTime.Now;
            _context.TableNote1.Add(note);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNote (long id, Note updatedNote)
        {
            var note = await _context.TableNote1.FindAsync(id);
            if(note == null)
                return NotFound("ТОвар не найден");
            note.Text = updatedNote.Text;
           
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var note = _context.TableNote1.Find(id);
            if (note == null) 
                return NotFound();
            _context.TableNote1.Remove(note);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

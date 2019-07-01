using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SongManager.Models;

namespace SongManager.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SongsController : Controller
    {
        private readonly SongManagerContext _context;

        public SongsController(SongManagerContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs()
        {
            return await _context.Song.ToListAsync();
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Song>> GetSong(Guid id)
        {
            var song = await _context.Song.FindAsync(id);

            if (song == null)
            {
                return NotFound();
            }

            return song;
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSong(Guid id, [FromBody]Song song)
        {
            if (id != song.Id)
            {
                return BadRequest();
            }

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong([FromBody]Song song)
        {
            _context.Song.Add(song);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Song>> DeleteSong(Guid id)
        {
            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Song.Remove(song);
            await _context.SaveChangesAsync();

            return song;
        }

        private bool SongExists(Guid id)
        {
            return _context.Song.Any(e => e.Id == id);
        }
    }
}

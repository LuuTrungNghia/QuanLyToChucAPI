using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyToChucAPI.Data;
using QuanLyToChucAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyToChucAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiLienHeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public NguoiLienHeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous] 
        public async Task<ActionResult<IEnumerable<NguoiLienHe>>> GetNguoiLienHes()
        {
            return await _context.NguoiLienHes.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<NguoiLienHe>> GetNguoiLienHe(int id)
        {
            var nguoiLienHe = await _context.NguoiLienHes.FindAsync(id);

            if (nguoiLienHe == null)
            {
                return NotFound();
            }

            return nguoiLienHe;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<NguoiLienHe>> PostNguoiLienHe(NguoiLienHe nguoiLienHe)
        {
            _context.NguoiLienHes.Add(nguoiLienHe);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetNguoiLienHe), new { id = nguoiLienHe.NguoiLienHeID }, nguoiLienHe);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")] 
        public async Task<ActionResult<NguoiLienHe>> PutNguoiLienHe(int id, NguoiLienHe nguoiLienHe)
        {
            if (id != nguoiLienHe.NguoiLienHeID)
            {
                return BadRequest();
            }

            _context.Entry(nguoiLienHe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NguoiLienHeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(nguoiLienHe);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteNguoiLienHe(int id)
        {
            var nguoiLienHe = await _context.NguoiLienHes.FindAsync(id);
            if (nguoiLienHe == null)
            {
                return NotFound();
            }

            _context.NguoiLienHes.Remove(nguoiLienHe);
            await _context.SaveChangesAsync();

            return Ok("Delete successfully!");
        }

        private bool NguoiLienHeExists(int id)
        {
            return _context.NguoiLienHes.Any(e => e.NguoiLienHeID == id);
        }
    }
}

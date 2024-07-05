using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyToChucAPI.Data;
using QuanLyToChucAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyToChucAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhuongThucLienLacController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PhuongThucLienLacController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous] 
        public async Task<ActionResult<IEnumerable<PhuongThucLienLac>>> GetPhuongThucLienLacs()
        {
            return await _context.PhuongThucLienLacs.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous] 
        public async Task<ActionResult<PhuongThucLienLac>> GetPhuongThucLienLac(int id)
        {
            var phuongThucLienLac = await _context.PhuongThucLienLacs.FindAsync(id);

            if (phuongThucLienLac == null)
            {
                return NotFound();
            }

            return phuongThucLienLac;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")] 
        public async Task<ActionResult<PhuongThucLienLac>> PostPhuongThucLienLac(PhuongThucLienLac phuongThucLienLac)
        {
            _context.PhuongThucLienLacs.Add(phuongThucLienLac);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPhuongThucLienLac), new { id = phuongThucLienLac.PhuongThucLienLacID }, phuongThucLienLac);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutPhuongThucLienLac(int id, PhuongThucLienLac phuongThucLienLac)
        {
            if (id != phuongThucLienLac.PhuongThucLienLacID)
            {
                return BadRequest();
            }

            _context.Entry(phuongThucLienLac).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhuongThucLienLacExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(phuongThucLienLac);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeletePhuongThucLienLac(int id)
        {
            var phuongThucLienLac = await _context.PhuongThucLienLacs.FindAsync(id);
            if (phuongThucLienLac == null)
            {
                return NotFound();
            }

            _context.PhuongThucLienLacs.Remove(phuongThucLienLac);
            await _context.SaveChangesAsync();

            return Ok("Delete successfully!");
        }

        private bool PhuongThucLienLacExists(int id)
        {
            return _context.PhuongThucLienLacs.Any(e => e.PhuongThucLienLacID == id);
        }
    }
}

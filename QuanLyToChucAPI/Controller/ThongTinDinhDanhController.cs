using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyToChucAPI.Data;
using QuanLyToChucAPI.Models;

namespace QuanLyToChucAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinDinhDanhController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ThongTinDinhDanhController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ThongTinDinhDanh>>> GetThongTinDinhDanhs()
        {
            return await _context.ThongTinDinhDanhs.ToListAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<ThongTinDinhDanh>> GetThongTinDinhDanh(int id)
        {
            var thongTinDinhDanh = await _context.ThongTinDinhDanhs.FindAsync(id);

            if (thongTinDinhDanh == null)
            {
                return NotFound();
            }

            return thongTinDinhDanh;
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<ThongTinDinhDanh>> PostThongTinDinhDanh(ThongTinDinhDanh thongTinDinhDanh)
        {
            _context.ThongTinDinhDanhs.Add(thongTinDinhDanh);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetThongTinDinhDanh), new { id = thongTinDinhDanh.ThongTinDinhDanhID }, thongTinDinhDanh);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutThongTinDinhDanh(int id, ThongTinDinhDanh thongTinDinhDanh)
        {
            if (id != thongTinDinhDanh.ThongTinDinhDanhID)
            {
                return BadRequest();
            }

            _context.Entry(thongTinDinhDanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThongTinDinhDanhExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(thongTinDinhDanh);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteThongTinDinhDanh(int id)
        {
            var thongTinDinhDanh = await _context.ThongTinDinhDanhs.FindAsync(id);
            if (thongTinDinhDanh == null)
            {
                return NotFound();
            }

            _context.ThongTinDinhDanhs.Remove(thongTinDinhDanh);
            await _context.SaveChangesAsync();

            return Ok("Delete successfully!");
        }

        private bool ThongTinDinhDanhExists(int id)
        {
            return _context.ThongTinDinhDanhs.Any(e => e.ThongTinDinhDanhID == id);
        }
    }
}

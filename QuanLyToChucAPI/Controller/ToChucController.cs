using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLyToChuc.API.Models;
using QuanLyToChucAPI.Data;

namespace QuanLyToChucAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToChucController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ToChucController(ApplicationDbContext context)
        {
            _context = context;
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ToChuc>>> GetToChucs()
        {
            return await _context.ToChucs.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<ToChuc>> GetToChuc(int id)
        {
            var toChuc = await _context.ToChucs.FindAsync(id);

            if (toChuc == null)
            {
                return NotFound();
            }

            return Ok(toChuc);
        }

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult<ToChuc>> PostToChuc(ToChuc toChuc)
        {
            _context.ToChucs.Add(toChuc);
            await _context.SaveChangesAsync();

            return Ok(toChuc);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> PutToChuc(int id, ToChuc toChuc)
        {
            if (id != toChuc.Id)
            {
                return BadRequest();
            }

            _context.Entry(toChuc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToChucExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(toChuc);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> DeleteToChuc(int id)
        {
            var toChuc = await _context.ToChucs.FindAsync(id);
            if (toChuc == null)
            {
                return NotFound();
            }

            _context.ToChucs.Remove(toChuc);
            await _context.SaveChangesAsync();

            return Ok("Delete successfully!");
        }

        private bool ToChucExists(int id)
        {
            return _context.ToChucs.Any(e => e.Id == id);
        }

        [HttpGet("{id}/details")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> GetToChucDetails(int id)
        {
            var toChucRes = await _context.ToChucs
                .Include(t => t.NguoiLienHes)
                .Select(se => new
                {
                    ToChuc = new
                    {
                        Id = se.Id,
                        Ten = se.TenToChuc,
                        MoTa = se.MoTa,
                    },
                    NguoiLienHes = se.NguoiLienHes.Select(s => new
                    {
                        NguoiLienHeID = s.NguoiLienHeID,
                        ToChucID = s.ToChucID,
                        Ho = s.Ho,
                        TenDemVaTen = s.TenDemVaTen,
                        ChucDanh = s.ChucDanh,
                        LoaiLienHe = s.LoaiLienHe,
                        TuNgay = s.TuNgay,
                        DenNgay = s.DenNgay
                    }).ToList()
                })
                .FirstOrDefaultAsync(t => t.ToChuc.Id == id);

            if (toChucRes == null)
            {
                return NotFound();
            }
            return Ok(toChucRes);
        }
    }
}
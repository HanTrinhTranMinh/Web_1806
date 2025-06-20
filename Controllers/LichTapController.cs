using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class LichTapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LichTapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LichTap
        public async Task<IActionResult> Index()
        {
            var list = await _context.LichTaps
                .Include(l => l.TheHoiVien)
                .Include(l => l.PhongTap)
                .Include(l => l.User)
                .ToListAsync();
            return View(list);
        }

        // GET: LichTap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var lichTap = await _context.LichTaps
                .Include(l => l.TheHoiVien)
                .Include(l => l.PhongTap)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.ID_LichTap == id);

            if (lichTap == null) return NotFound();

            return View(lichTap);
        }

        // GET: LichTap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LichTap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_LichTap,ID_TheHoiVien,ID_PhongTap,ngayTap,gioBatDau,gioKetThuc,noiDung,ID_User")] LichTap lichTap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lichTap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lichTap);
        }

        // GET: LichTap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var lichTap = await _context.LichTaps.FindAsync(id);
            if (lichTap == null) return NotFound();

            return View(lichTap);
        }

        // POST: LichTap/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_LichTap,ID_TheHoiVien,ID_PhongTap,ngayTap,gioBatDau,gioKetThuc,noiDung,ID_User")] LichTap lichTap)
        {
            if (id != lichTap.ID_LichTap) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lichTap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LichTapExists(lichTap.ID_LichTap)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lichTap);
        }

        // GET: LichTap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var lichTap = await _context.LichTaps
                .Include(l => l.TheHoiVien)
                .Include(l => l.PhongTap)
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.ID_LichTap == id);

            if (lichTap == null) return NotFound();

            return View(lichTap);
        }

        // POST: LichTap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lichTap = await _context.LichTaps.FindAsync(id);
            if (lichTap != null)
            {
                _context.LichTaps.Remove(lichTap);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LichTapExists(int id)
        {
            return _context.LichTaps.Any(e => e.ID_LichTap == id);
        }
    }
}

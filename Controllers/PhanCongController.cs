using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class PhanCongController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhanCongController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhanCong
        public async Task<IActionResult> Index()
        {
            var list = await _context.PhanCongs
                .Include(p => p.PhongTap)
                .Include(p => p.CaLamViec)
                .Include(p => p.User)
                .Include(p => p.AdminCreator)
                .ToListAsync();
            return View(list);
        }

        // GET: PhanCong/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var phanCong = await _context.PhanCongs
                .Include(p => p.PhongTap)
                .Include(p => p.CaLamViec)
                .Include(p => p.User)
                .Include(p => p.AdminCreator)
                .FirstOrDefaultAsync(m => m.ID_PhanCong == id);

            if (phanCong == null) return NotFound();

            return View(phanCong);
        }

        // GET: PhanCong/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhanCong/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_PhanCong,ID_PhongTap,ID_CaLam,ID_User,ngayPhanCong,createdByAdminID")] PhanCong phanCong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phanCong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phanCong);
        }

        // GET: PhanCong/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var phanCong = await _context.PhanCongs.FindAsync(id);
            if (phanCong == null) return NotFound();

            return View(phanCong);
        }

        // POST: PhanCong/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_PhanCong,ID_PhongTap,ID_CaLam,ID_User,ngayPhanCong,createdByAdminID")] PhanCong phanCong)
        {
            if (id != phanCong.ID_PhanCong) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phanCong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhanCongExists(phanCong.ID_PhanCong)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phanCong);
        }

        // GET: PhanCong/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var phanCong = await _context.PhanCongs
                .Include(p => p.PhongTap)
                .Include(p => p.CaLamViec)
                .Include(p => p.User)
                .Include(p => p.AdminCreator)
                .FirstOrDefaultAsync(m => m.ID_PhanCong == id);

            if (phanCong == null) return NotFound();

            return View(phanCong);
        }

        // POST: PhanCong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phanCong = await _context.PhanCongs.FindAsync(id);
            if (phanCong != null)
            {
                _context.PhanCongs.Remove(phanCong);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PhanCongExists(int id)
        {
            return _context.PhanCongs.Any(e => e.ID_PhanCong == id);
        }
    }
}

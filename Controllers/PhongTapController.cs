using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class PhongTapController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PhongTapController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PhongTap
        public async Task<IActionResult> Index()
        {
            var list = await _context.PhongTaps
                .Include(p => p.ThietBi)
                .ToListAsync();
            return View(list);
        }

        // GET: PhongTap/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var phongTap = await _context.PhongTaps
                .Include(p => p.ThietBi)
                .Include(p => p.PhanCongs)
                .FirstOrDefaultAsync(m => m.ID_PhongTap == id);

            if (phongTap == null) return NotFound();

            return View(phongTap);
        }

        // GET: PhongTap/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PhongTap/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_PhongTap,tenPhongTap,diaChiPhong,sucChua,sucChuaThietBi,ID_ThietBi")] PhongTap phongTap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phongTap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phongTap);
        }

        // GET: PhongTap/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var phongTap = await _context.PhongTaps.FindAsync(id);
            if (phongTap == null) return NotFound();

            return View(phongTap);
        }

        // POST: PhongTap/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_PhongTap,tenPhongTap,diaChiPhong,sucChua,sucChuaThietBi,ID_ThietBi")] PhongTap phongTap)
        {
            if (id != phongTap.ID_PhongTap) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phongTap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhongTapExists(phongTap.ID_PhongTap)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(phongTap);
        }

        // GET: PhongTap/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var phongTap = await _context.PhongTaps
                .Include(p => p.ThietBi)
                .FirstOrDefaultAsync(m => m.ID_PhongTap == id);

            if (phongTap == null) return NotFound();

            return View(phongTap);
        }

        // POST: PhongTap/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phongTap = await _context.PhongTaps.FindAsync(id);
            if (phongTap != null)
            {
                _context.PhongTaps.Remove(phongTap);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PhongTapExists(int id)
        {
            return _context.PhongTaps.Any(e => e.ID_PhongTap == id);
        }
    }
}

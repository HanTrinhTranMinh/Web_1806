using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class ThietBiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ThietBiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ThietBi
        public async Task<IActionResult> Index()
        {
            var list = await _context.ThietBis
                .Include(t => t.User)
                .ToListAsync();
            return View(list);
        }

        // GET: ThietBi/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var thietBi = await _context.ThietBis
                .Include(t => t.User)
                .Include(t => t.HoaDon_ThanhLies)
                .Include(t => t.PhongTaps)
                .FirstOrDefaultAsync(m => m.ID_ThietBi == id);

            if (thietBi == null) return NotFound();

            return View(thietBi);
        }

        // GET: ThietBi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThietBi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_ThietBi,tenThietBi,soLuong,tinhTrang,ID_User")] ThietBi thietBi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thietBi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thietBi);
        }

        // GET: ThietBi/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi == null) return NotFound();

            return View(thietBi);
        }

        // POST: ThietBi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_ThietBi,tenThietBi,soLuong,tinhTrang,ID_User")] ThietBi thietBi)
        {
            if (id != thietBi.ID_ThietBi) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thietBi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThietBiExists(thietBi.ID_ThietBi)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(thietBi);
        }

        // GET: ThietBi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var thietBi = await _context.ThietBis
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ID_ThietBi == id);

            if (thietBi == null) return NotFound();

            return View(thietBi);
        }

        // POST: ThietBi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var thietBi = await _context.ThietBis.FindAsync(id);
            if (thietBi != null)
            {
                _context.ThietBis.Remove(thietBi);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ThietBiExists(int id)
        {
            return _context.ThietBis.Any(e => e.ID_ThietBi == id);
        }
    }
}

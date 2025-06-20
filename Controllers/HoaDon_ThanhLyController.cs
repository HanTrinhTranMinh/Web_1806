using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class HoaDonThanhLyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonThanhLyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDonThanhLy
        public async Task<IActionResult> Index()
        {
            var list = await _context.HoaDon_ThanhLys
                .Include(h => h.ThietBi)
                .Include(h => h.User)
                .ToListAsync();
            return View(list);
        }

        // GET: HoaDonThanhLy/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon_ThanhLys
                .Include(h => h.ThietBi)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.ID_ThanhLi == id);

            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // GET: HoaDonThanhLy/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoaDonThanhLy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_ThanhLi,ID_ThietBi,soTien,ngayThanhLy,ID_User")] HoaDon_ThanhLy hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDon);
        }

        // GET: HoaDonThanhLy/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon_ThanhLys.FindAsync(id);
            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // POST: HoaDonThanhLy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_ThanhLi,ID_ThietBi,soTien,ngayThanhLy,ID_User")] HoaDon_ThanhLy hoaDon)
        {
            if (id != hoaDon.ID_ThanhLi) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.ID_ThanhLi)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDon);
        }

        // GET: HoaDonThanhLy/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon_ThanhLys
                .Include(h => h.ThietBi)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.ID_ThanhLi == id);

            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // POST: HoaDonThanhLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDon_ThanhLys.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDon_ThanhLys.Remove(hoaDon);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDon_ThanhLys.Any(e => e.ID_ThanhLi == id);
        }
    }
}

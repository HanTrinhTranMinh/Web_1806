using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class HoaDonThanhToanController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoaDonThanhToanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoaDonThanhToan
        public async Task<IActionResult> Index()
        {
            var list = await _context.HoaDon_ThanhToans
                .Include(h => h.GoiTap)
                .Include(h => h.User)
                .ToListAsync();
            return View(list);
        }

        // GET: HoaDonThanhToan/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon_ThanhToans
                .Include(h => h.GoiTap)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.ID_HoaDon == id);

            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // GET: HoaDonThanhToan/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoaDonThanhToan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_HoaDon,ID_GoiTap,soTien,ngayThu,ID_User")] HoaDon_ThanhToan hoaDon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoaDon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDon);
        }

        // GET: HoaDonThanhToan/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon_ThanhToans.FindAsync(id);
            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // POST: HoaDonThanhToan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_HoaDon,ID_GoiTap,soTien,ngayThu,ID_User")] HoaDon_ThanhToan hoaDon)
        {
            if (id != hoaDon.ID_HoaDon) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoaDonExists(hoaDon.ID_HoaDon)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hoaDon);
        }

        // GET: HoaDonThanhToan/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hoaDon = await _context.HoaDon_ThanhToans
                .Include(h => h.GoiTap)
                .Include(h => h.User)
                .FirstOrDefaultAsync(m => m.ID_HoaDon == id);

            if (hoaDon == null) return NotFound();

            return View(hoaDon);
        }

        // POST: HoaDonThanhToan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoaDon = await _context.HoaDon_ThanhToans.FindAsync(id);
            if (hoaDon != null)
            {
                _context.HoaDon_ThanhToans.Remove(hoaDon);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool HoaDonExists(int id)
        {
            return _context.HoaDon_ThanhToans.Any(e => e.ID_HoaDon == id);
        }
    }
}

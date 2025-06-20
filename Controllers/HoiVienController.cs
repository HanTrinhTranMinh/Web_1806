using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class HoiVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HoiVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HoiVien
        public async Task<IActionResult> Index()
        {
            var list = await _context.HoiViens.ToListAsync();
            return View(list);
        }

        // GET: HoiVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var hoiVien = await _context.HoiViens
                .FirstOrDefaultAsync(m => m.ID_HoiVien == id);

            if (hoiVien == null) return NotFound();

            return View(hoiVien);
        }

        // GET: HoiVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HoiVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_HoiVien,tenHoiVien,ngaySinh,gioiTinh,diaChi,sdt,email,ngayGiaNhap,ID_User")] HoiVien hoiVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hoiVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hoiVien);
        }

        // GET: HoiVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var hoiVien = await _context.HoiViens.FindAsync(id);
            if (hoiVien == null) return NotFound();

            return View(hoiVien);
        }

        // POST: HoiVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_HoiVien,tenHoiVien,ngaySinh,gioiTinh,diaChi,sdt,email,ngayGiaNhap,ID_User")] HoiVien hoiVien)
        {
            if (id != hoiVien.ID_HoiVien) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hoiVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HoiVienExists(hoiVien.ID_HoiVien)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(hoiVien);
        }

        // GET: HoiVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var hoiVien = await _context.HoiViens
                .FirstOrDefaultAsync(m => m.ID_HoiVien == id);

            if (hoiVien == null) return NotFound();

            return View(hoiVien);
        }

        // POST: HoiVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hoiVien = await _context.HoiViens.FindAsync(id);
            if (hoiVien != null)
            {
                _context.HoiViens.Remove(hoiVien);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool HoiVienExists(int id)
        {
            return _context.HoiViens.Any(e => e.ID_HoiVien == id);
        }
    }
}

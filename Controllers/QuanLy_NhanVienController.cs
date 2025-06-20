using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class QuanLyNhanVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuanLyNhanVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuanLyNhanVien
        public async Task<IActionResult> Index()
        {
            var list = await _context.QuanLy_NhanViens
                .Include(q => q.AdminUser)
                .Include(q => q.ManagedUser)
                .ToListAsync();

            return View(list);
        }

        // GET: QuanLyNhanVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var qlnv = await _context.QuanLy_NhanViens
                .Include(q => q.AdminUser)
                .Include(q => q.ManagedUser)
                .FirstOrDefaultAsync(m => m.ID_QuanLyNhanVien == id);

            if (qlnv == null) return NotFound();

            return View(qlnv);
        }

        // GET: QuanLyNhanVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLyNhanVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_QuanLyNhanVien,ID_Admin,ID_User")] QuanLy_NhanVien model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: QuanLyNhanVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var qlnv = await _context.QuanLy_NhanViens.FindAsync(id);
            if (qlnv == null) return NotFound();

            return View(qlnv);
        }

        // POST: QuanLyNhanVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_QuanLyNhanVien,ID_Admin,ID_User")] QuanLy_NhanVien model)
        {
            if (id != model.ID_QuanLyNhanVien) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QLNVExists(model.ID_QuanLyNhanVien)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: QuanLyNhanVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var qlnv = await _context.QuanLy_NhanViens
                .Include(q => q.AdminUser)
                .Include(q => q.ManagedUser)
                .FirstOrDefaultAsync(m => m.ID_QuanLyNhanVien == id);

            if (qlnv == null) return NotFound();

            return View(qlnv);
        }

        // POST: QuanLyNhanVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qlnv = await _context.QuanLy_NhanViens.FindAsync(id);
            if (qlnv != null)
            {
                _context.QuanLy_NhanViens.Remove(qlnv);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool QLNVExists(int id)
        {
            return _context.QuanLy_NhanViens.Any(e => e.ID_QuanLyNhanVien == id);
        }
    }
}

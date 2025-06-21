using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class TheHoiVienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TheHoiVienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TheHoiVien
        public async Task<IActionResult> Index()
        {
            var list = await _context.TheHoiViens
                .Include(t => t.HoiVien)
                .Include(t => t.GoiTap)
                .Include(t => t.User)
                .ToListAsync();
            return View(list);
        }

        // GET: TheHoiVien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var the = await _context.TheHoiViens
                .Include(t => t.HoiVien)
                .Include(t => t.GoiTap)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ID_TheHoiVien == id);

            if (the == null) return NotFound();

            return View(the);
        }

        // GET: TheHoiVien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TheHoiVien/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_TheHoiVien,ID_HoiVien,ID_GoiTap,ngayDangKy,ngayHetHan,tinhTrangThe,ID_User")] TheHoiVien theHoiVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(theHoiVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(theHoiVien);
        }

        // GET: TheHoiVien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var theHoiVien = await _context.TheHoiViens.FindAsync(id);
            if (theHoiVien == null) return NotFound();

            return View(theHoiVien);
        }

        // POST: TheHoiVien/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_TheHoiVien,ID_HoiVien,ID_GoiTap,ngayDangKy,ngayHetHan,tinhTrangThe,ID_User")] TheHoiVien theHoiVien)
        {
            if (id != theHoiVien.ID_TheHoiVien) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(theHoiVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TheHoiVienExists(theHoiVien.ID_TheHoiVien)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(theHoiVien);
        }

        // GET: TheHoiVien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var theHoiVien = await _context.TheHoiViens
                .Include(t => t.HoiVien)
                .Include(t => t.GoiTap)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.ID_TheHoiVien == id);

            if (theHoiVien == null) return NotFound();

            return View(theHoiVien);
        }

        // POST: TheHoiVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var theHoiVien = await _context.TheHoiViens.FindAsync(id);
            if (theHoiVien != null)
            {
                _context.TheHoiViens.Remove(theHoiVien);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        //Gia hạn thẻ hội viên
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GiaHanTheHoiVien(int id, DateTime ngayHetHan)
        {
            var theHoiVien = await _context.TheHoiViens.FindAsync(id);
            if (theHoiVien == null) return NotFound();

            theHoiVien.ngayHetHan = ngayHetHan;
            _context.Update(theHoiVien);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool TheHoiVienExists(int id)
        {
            return _context.TheHoiViens.Any(e => e.ID_TheHoiVien == id);
        }
    }
}

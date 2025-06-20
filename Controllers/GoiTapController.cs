using GymManagement.Data; // Namespace chứa ApplicationDbContext
using GymManagement.Models; // Namespace chứa model BaoCao
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymManagement.Controllers
{
    public class GoiTapController : Controller
    {

        private readonly ApplicationDbContext _context;
        // Tạo một đối tượng ApplicationDbContext để truy cập cơ sở dữ liệu

        public GoiTapController(ApplicationDbContext context)
        {
            _context = context; // Khởi tạo context từ dependency injection
        }

        // GET: BaoCao
        public async Task<IActionResult> Index()
        // Phương thức để lấy danh sách báo cáo
        {
            var goiTaps = await _context.GoiTaps.ToListAsync();
            return View(goiTaps);
        }

        // GET: BaoCao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTaps
                .FirstOrDefaultAsync(m => m.ID_GoiTap == id);
            if (goiTap == null)
            {
                return NotFound();
            }

            return View(goiTap);
        }

        // GET: BaoCao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaoCao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_GoiTap,tenGoi,soTien,moTa,ngayBatDau,ngayKetThuc,soBuoi")] GoiTap goiTap)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goiTap);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(goiTap);
        }

        // GET: BaoCao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTaps.FindAsync(id);
            if (goiTap == null)
            {
                return NotFound();
            }
            return View(goiTap);
        }

        // POST: BaoCao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_GoiTap,tenGoi,soTien,moTa,ngayBatDau,ngayKetThuc,soBuoi")] GoiTap goiTap)
        {
            if (id != goiTap.ID_GoiTap)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(goiTap);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GoiTapexist(goiTap.ID_GoiTap))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(goiTap);
        }

        // GET: BaoCao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goiTap = await _context.GoiTaps
                .FirstOrDefaultAsync(m => m.ID_GoiTap == id);
            if (goiTap == null)
            {
                return NotFound();
            }

            return View(goiTap);
        }

        // POST: BaoCao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var goiTap = await _context.GoiTaps.FindAsync(id);
            if (goiTap != null)
            {
                _context.GoiTaps.Remove(goiTap);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool GoiTapexist(int id)
        {
            return _context.GoiTaps.Any(e => e.ID_GoiTap == id);
        }
    }
}
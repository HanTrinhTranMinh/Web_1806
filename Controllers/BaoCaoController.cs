using System.ComponentModel;
using GymManagement.Data; // Namespace chứa ApplicationDbContext
using GymManagement.Models; // Namespace chứa model BaoCao
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


// Add the correct namespace for ExcelHelper below, for example:

namespace GymManagement.Controllers
{
    public class BaoCaoController : Controller
    {

        private readonly ApplicationDbContext _context;
        // Tạo một đối tượng ApplicationDbContext để truy cập cơ sở dữ liệu

        public BaoCaoController(ApplicationDbContext context)
        {
            _context = context; // Khởi tạo context từ dependency injection
        }

        // GET: BaoCao
        public async Task<IActionResult> Index()
        // Phương thức để lấy danh sách báo cáo
        {
            var baoCaos = await _context.BaoCaos.ToListAsync();
            return View(baoCaos);
        }

        // GET: BaoCao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoCao = await _context.BaoCaos
                .FirstOrDefaultAsync(m => m.ID_BaoCao == id);
            if (baoCao == null)
            {
                return NotFound();
            }

            return View(baoCao);
        }

        // GET: BaoCao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BaoCao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_BaoCao,tenBaoCao,ngayTao,noiDung")] BaoCao baoCao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baoCao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baoCao);
        }

        // GET: BaoCao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoCao = await _context.BaoCaos.FindAsync(id);
            if (baoCao == null)
            {
                return NotFound();
            }
            return View(baoCao);
        }

        // POST: BaoCao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_BaoCao,tenBaoCao,ngayTao,noiDung")] BaoCao baoCao)
        {
            if (id != baoCao.ID_BaoCao)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baoCao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaoCaoExists(baoCao.ID_BaoCao))
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
            return View(baoCao);
        }

        // GET: BaoCao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baoCao = await _context.BaoCaos
                .FirstOrDefaultAsync(m => m.ID_BaoCao == id);
            if (baoCao == null)
            {
                return NotFound();
            }

            return View(baoCao);
        }

        // POST: BaoCao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baoCao = await _context.BaoCaos.FindAsync(id);
            if (baoCao != null)
            {
                _context.BaoCaos.Remove(baoCao);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BaoCaoExists(int id)
        {
            return _context.BaoCaos.Any(e => e.ID_BaoCao == id);
        }
    }
}
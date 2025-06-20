using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymManagement.Data;
using GymManagement.Models;

namespace GymManagement.Controllers
{
    public class CaLamViecController : Controller
    {
        // Tạo một đối tượng ApplicationDbContext để truy cập cơ sở dữ liệu
        private readonly ApplicationDbContext _context;
        public CaLamViecController(ApplicationDbContext context)
        {
            _context = context; // Khởi tạo context từ dependency injection
        }


        //GET: CaLamViec
        public async Task<IActionResult> Index()
        {
            var caLamViecs = await _context.CaLamViecs.ToListAsync();
            return View(caLamViecs);
        }

        //GET: CaLamViec/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Trả về NotFound nếu id là null
            }
            var caLamViec = await _context.CaLamViecs
                .FirstOrDefaultAsync(m => m.ID_Ca == id); // Tìm kiếm CaLamViec theo Id
            if (caLamViec == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy CaLamViec
            }
            return View(caLamViec); // Trả về view để hiển thị chi tiết
        }
        //GET: CaLamViec/Create
        public IActionResult  Create()
        {
            return View();
        }

        [HttpPost] // Http Post method có tác dụng xử lý dữ liệu từ form
        [ValidateAntiForgeryToken] // Bảo vệ khỏi tấn công CSRF
        public async Task<IActionResult> Create([Bind("ID_Ca,tenCa,moTa")] CaLamViec caLamViec)
        {
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của dữ liệu
            {
                _context.Add(caLamViec); // Thêm đối tượng vào DbContext
                await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách
            }
            return View(caLamViec); // Trả về view nếu có lỗi
        }


        //GET: CaLamViec/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Trả về NotFound nếu id là null
            }
            var caLamViec = await _context.CaLamViecs.FindAsync(id); // Tìm kiếm CaLamViec theo Id
            if (caLamViec == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy CaLamViec
            }
            return View(caLamViec); // Trả về view để chỉnh sửa
        }

        //POST: CaLamViec/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken] // Bảo vệ khỏi tấn công CSRF
        public async Task<IActionResult> Edit(int id, [Bind("ID_Ca,tenCa,moTa")] CaLamViec caLamViec)
        {
            if (id != caLamViec.ID_Ca) // Kiểm tra xem Id có khớp với đối tượng không
            {
                return NotFound(); // Trả về NotFound nếu không khớp
            }
            if (ModelState.IsValid) // Kiểm tra tính hợp lệ của dữ liệu
            {
                try
                {
                    _context.Update(caLamViec); // Cập nhật đối tượng trong DbContext
                    await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
                }
                catch (DbUpdateConcurrencyException) // Xử lý lỗi đồng thời cập nhật
                {
                    if (!_context.CaLamViecs.Any(e => e.ID_Ca == caLamViec.ID_Ca)) // Kiểm tra xem đối tượng có tồn tại không
                    {
                        return NotFound(); // Trả về NotFound nếu không tìm thấy
                    }
                    else
                    {
                        throw; // Ném lại ngoại lệ nếu có lỗi khác
                    }
                }
                return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách
            }
            return View(caLamViec); // Trả về view nếu có lỗi
        }

        //GET: CaLamViec/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Trả về NotFound nếu id là null
            }
            var caLamViec = await _context.CaLamViecs
                .FirstOrDefaultAsync(m => m.ID_Ca == id); // Tìm kiếm CaLamViec theo Id
            if (caLamViec.ID_Ca == null)
            {
                return NotFound(); // Trả về NotFound nếu không tìm thấy CaLamViec
            }
            return View(caLamViec); // Trả về view để xác nhận xóa
        }

        //POST: CaLamViec/Delete/5
        [HttpPost, ActionName("Delete")] // Http Post method có tác dụng xử lý dữ liệu từ form
        [ValidateAntiForgeryToken] // Bảo vệ khỏi tấn công CSRF
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var caLamViec = await _context.CaLamViecs.FindAsync(id); // Tìm kiếm CaLamViec theo Id
            if (caLamViec.ID_Ca != null) // Kiểm tra xem đối tượng có tồn tại không
            {
                _context.CaLamViecs.Remove(caLamViec); // Xóa đối tượng khỏi DbContext
                await _context.SaveChangesAsync(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            return RedirectToAction(nameof(Index)); // Chuyển hướng về trang danh sách
        }
    }
}
using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;



namespace GymManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;


        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: User
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.Include(u => u.Role).ToListAsync();
            return View(users);
        }

        // GET: User/Details/id
        public async Task<IActionResult> Details(string id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.ID_User == id);

            if (user == null) return NotFound();

            return View(user);
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Auth/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterFirebaseUser(FirebaseUserModel input)
        {
            var exists = await _context.Users.AnyAsync(u => u.ID_User == input.FirebaseUid);
            if (exists)
                return BadRequest("Tài khoản đã tồn tại.");

            var user = new User
            {
                ID_User = input.FirebaseUid,
                TenDangNhap = input.DisplayName,
                email = input.Email,
                ID_Role = await _context.Roles.Where(r => r.tenRole == "KhachHang").Select(r => r.ID_Role).FirstAsync()
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // ✅ Gán role vào Firebase token (custom claims)
            await FirebaseAuth.DefaultInstance.SetCustomUserClaimsAsync(input.FirebaseUid, new Dictionary<string, object>
            {
                { "role", "khachhang" }
            });

            return Ok("Đăng ký thành công.");
        }



        // POST: /Admin/CreateUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("ID_User,TenDangNhap,email,ID_Role")] User user)
        {
            var exists = await _context.Users.AnyAsync(u => u.ID_User == user.ID_User);
            if (exists)
                return BadRequest("Firebase UID đã tồn tại.");

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_User,TenDangNhap,email,ID_Role")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Edit/id
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: User/Edit/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("ID_User,TenDangNhap,email,ID_Role")] User user)
        {
            if (id != user.ID_User) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.ID_User)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: User/Delete/id
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.ID_User == id);

            if (user == null) return NotFound();

            return View(user);
        }

        // POST: User/DeleteConfirmed/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.ID_User == id);
        }
    }
}

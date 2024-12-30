using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdvanceDataAccessAssignment.Data;
using AdvanceDataAccessAssignment.Models;

namespace AdvanceDataAccessAssignment.Controllers
{
    /// <summary>
    /// Controller to handle user operations.
    /// </summary>
    public class UsersController : Controller
    {
        private readonly AdvanceDataAccessAssignmentContext _context;

        public UsersController(AdvanceDataAccessAssignmentContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Displays all users in the system.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }

        /// <summary>
        /// Displays the details of a specific user.
        /// </summary>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Displays the create user form.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Creates a new user in the system.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,PhoneNumber,EmailAddress,ElectronicName")] Users user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Add error handling, such as logging or user-friendly messages
                    return BadRequest($"Error occurred while adding user: {ex.Message}");
                }
            }
            return View(user);
        }

        /// <summary>
        /// Displays the edit user form for a specific user.
        /// </summary>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        /// <summary>
        /// Updates user details in the system.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,PhoneNumber,EmailAddress,ElectronicName")] Users user)
        {
            if (id != user.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsersExists(user.UserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        // Handle concurrency error (e.g., log the error)
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        /// <summary>
        /// Displays the delete user confirmation page.
        /// </summary>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        /// <summary>
        /// Deletes the user from the system.
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// private method to check whether a user exists or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
    }
}

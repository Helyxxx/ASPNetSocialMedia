using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Data;
using ASPNetSocialMedia.Models;

namespace ASPNetSocialMedia.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationUser
        public async Task<IActionResult> Index()
        {
              return View(await _context.ApplicationUser.ToListAsync());
        }

        // GET: ApplicationUser/Details/5

        public async Task<IActionResult> Details(string? id)
        {
            if (id == null || _context.ApplicationUser == null)

            {
                return NotFound();
            }

            var ApplicationUser = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // GET: ApplicationUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkEmail=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Email,FirstName,LastName,DateOfBirth,Biography,ProfileImage,Address,Age")] ApplicationUser ApplicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ApplicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ApplicationUser);
        }

        // GET: ApplicationUser/Edit/5
        public async Task<IActionResult> Edit(string? email)
        {
            if (email == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _context.ApplicationUser.FindAsync(email);
            if (ApplicationUser == null)
            {
                return NotFound();
            }
            return View(ApplicationUser);
        }

        // POST: ApplicationUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkEmail=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string? email, [Bind("Email,FirstName,LastName,DateOfBirth,Biography,ProfileImage,Address,Age")] ApplicationUser ApplicationUser)
        {
            if (email != ApplicationUser.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ApplicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(ApplicationUser.Email))
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
            return View(ApplicationUser);
        }

        // GET: ApplicationUser/Delete/5

        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var ApplicationUser = await _context.ApplicationUser

                .FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return View(ApplicationUser);
        }

        // POST: ApplicationUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(string? id)

        {
            if (_context.ApplicationUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ApplicationUser'  is null.");
            }

            var ApplicationUser = await _context.ApplicationUser.FindAsync(id);

            if (ApplicationUser != null)
            {
                _context.ApplicationUser.Remove(ApplicationUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string? id)
        {
          return _context.ApplicationUser.Any(e => e.Id == id);

        }
    }
}

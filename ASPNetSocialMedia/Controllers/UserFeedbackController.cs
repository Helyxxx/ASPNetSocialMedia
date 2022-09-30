using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Data;
using ASPNetSocialMedia.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace ASPNetSocialMedia.Controllers
{
    
    public class UserFeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserFeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserFeedback
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
              return View(await _context.UserFeedback.ToListAsync());
        }

        // GET: UserFeedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.UserFeedback == null)
            {
                return NotFound();
            }

            var userFeedback = await _context.UserFeedback
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (userFeedback == null)
            {
                return NotFound();
            }

            return View(userFeedback);
        }

        // GET: UserFeedback/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserFeedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,FeedbackName,FeedbackEmail,FeedbackMessage,CreationDate")] UserFeedback userFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userFeedback);
                await _context.SaveChangesAsync();

            }
            return View(userFeedback);
        }
        [Authorize(Roles = "Admin")]
        // GET: UserFeedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserFeedback == null)
            {
                return NotFound();
            }

            var userFeedback = await _context.UserFeedback.FindAsync(id);
            if (userFeedback == null)
            {
                return NotFound();
            }
            return View(userFeedback);
        }
        [Authorize(Roles = "Admin")]
        // POST: UserFeedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,FeedbackName,FeedbackEmail,FeedbackMessage,CreationDate")] UserFeedback userFeedback)
        {
            if (id != userFeedback.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserFeedbackExists(userFeedback.FeedbackId))
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
            return View(userFeedback);
        }
        [Authorize(Roles = "Admin")]
        // GET: UserFeedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserFeedback == null)
            {
                return NotFound();
            }

            var userFeedback = await _context.UserFeedback
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (userFeedback == null)
            {
                return NotFound();
            }

            return View(userFeedback);
        }
        [Authorize(Roles = "Admin")]
        // POST: UserFeedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserFeedback == null)
            {
                return Problem("Entity set 'ApplicationDbContext.UserFeedback'  is null.");
            }
            var userFeedback = await _context.UserFeedback.FindAsync(id);
            if (userFeedback != null)
            {
                _context.UserFeedback.Remove(userFeedback);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserFeedbackExists(int id)
        {
          return _context.UserFeedback.Any(e => e.FeedbackId == id);
        }
    }
}

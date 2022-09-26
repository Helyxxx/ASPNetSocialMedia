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
    public class PrivateMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrivateMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PrivateMessages
        public async Task<IActionResult> Index()
        {
              return View(await _context.PrivateMessage.ToListAsync());
        }

        // GET: PrivateMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PrivateMessage == null)
            {
                return NotFound();
            }

            var privateMessage = await _context.PrivateMessage
                .FirstOrDefaultAsync(m => m.PrivateMessageId == id);
            if (privateMessage == null)
            {
                return NotFound();
            }

            return View(privateMessage);
        }

        // GET: PrivateMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PrivateMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrivateMessageId,PrivateMessageContent,WhoPosted")] PrivateMessage privateMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privateMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(privateMessage);
        }

        // GET: PrivateMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PrivateMessage == null)
            {
                return NotFound();
            }

            var privateMessage = await _context.PrivateMessage.FindAsync(id);
            if (privateMessage == null)
            {
                return NotFound();
            }
            return View(privateMessage);
        }

        // POST: PrivateMessages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("PrivateMessageId,PrivateMessageContent,WhoPosted")] PrivateMessage privateMessage)
        {
            if (id != privateMessage.PrivateMessageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(privateMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivateMessageExists(privateMessage.PrivateMessageId))
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
            return View(privateMessage);
        }

        // GET: PrivateMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PrivateMessage == null)
            {
                return NotFound();
            }

            var privateMessage = await _context.PrivateMessage
                .FirstOrDefaultAsync(m => m.PrivateMessageId == id);
            if (privateMessage == null)
            {
                return NotFound();
            }

            return View(privateMessage);
        }

        // POST: PrivateMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.PrivateMessage == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PrivateMessage'  is null.");
            }
            var privateMessage = await _context.PrivateMessage.FindAsync(id);
            if (privateMessage != null)
            {
                _context.PrivateMessage.Remove(privateMessage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivateMessageExists(int? id)
        {
          return _context.PrivateMessage.Any(e => e.PrivateMessageId == id);
        }
    }
}

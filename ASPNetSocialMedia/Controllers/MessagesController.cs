using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASPNetSocialMedia.Data;
using ASPNetSocialMedia.Models;
using Microsoft.Data.SqlClient;

namespace ASPNetSocialMedia.Controllers
{
    public class MessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Messages
        //public async Task<IActionResult> Index()
        //{
        //      return View(await _context.Messages.ToListAsync());
        //}

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;
       

            var messages = from m in _context.Messages
                           select m;

            messages = messages.Where(s => s.FriendEmail.Contains(User.Identity.Name));

            if (!String.IsNullOrEmpty(searchString))
            {
                messages = messages.Where(s => s.UserEmail.Contains(searchString));
            }




            switch (sortOrder)
            {
                case "name_desc":
                    messages = messages.OrderByDescending(m => m.FriendEmail);
                    break;
                case "Date":
                    messages = messages.OrderBy(m => m.CreationDate);
                    break;
                case "date_desc":
                    messages = messages.OrderByDescending(m => m.CreationDate);
                    break;
                default:
                    messages = messages.OrderBy(m => m.FriendEmail);
                    break;
            }
            return View(await messages.AsNoTracking().ToListAsync());
        }

        public async Task<IActionResult> SentMessages(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;


            var messages = from m in _context.Messages
                           select m;

            messages = messages.Where(s => s.UserEmail.Contains(User.Identity.Name));

            if (!String.IsNullOrEmpty(searchString))
            {
                messages = messages.Where(s => s.FriendEmail.Contains(searchString));
            }




            switch (sortOrder)
            {
                case "name_desc":
                    messages = messages.OrderByDescending(m => m.FriendEmail);
                    break;
                case "Date":
                    messages = messages.OrderBy(m => m.CreationDate);
                    break;
                case "date_desc":
                    messages = messages.OrderByDescending(m => m.CreationDate);
                    break;
                default:
                    messages = messages.OrderBy(m => m.FriendEmail);
                    break;
            }
            return View(await messages.AsNoTracking().ToListAsync());
        }

        // GET: Messages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // GET: Messages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MessageId,MessageContent,UserEmail,FriendEmail,CreationDate")] Messages messages)
        {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=aspnet-ASPNetSocialMedia-2E74CB14-DD3A-4442-9DCF-EC4C63E8F3F6; Integrated Security=True");
            con.Open();

            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [dbo].[AspNetUsers] WHERE [Email] = '" + messages.FriendEmail + "'", con);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            if (UserExist > 0)
            {
                con.Close();
                if (ModelState.IsValid)
                {
                    _context.Add(messages);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(messages);
            }
            else
            {
                Console.WriteLine("Error, user doesn't exist");
                con.Close();
                ViewData["Success"] = "No user with this email is registered";
                return View(messages);
            }
            
        }

        // GET: Messages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages.FindAsync(id);
            if (messages == null)
            {
                return NotFound();
            }
            return View(messages);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("MessageId,MessageContent,UserEmail,FriendEmail,CreationDate")] Messages messages)
        {
            if (id != messages.MessageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(messages);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MessagesExists(messages.MessageId))
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
            return View(messages);
        }

        // GET: Messages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Messages == null)
            {
                return NotFound();
            }

            var messages = await _context.Messages
                .FirstOrDefaultAsync(m => m.MessageId == id);
            if (messages == null)
            {
                return NotFound();
            }

            return View(messages);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (_context.Messages == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Messages'  is null.");
            }
            var messages = await _context.Messages.FindAsync(id);
            if (messages != null)
            {
                _context.Messages.Remove(messages);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MessagesExists(int? id)
        {
          return _context.Messages.Any(e => e.MessageId == id);
        }
    }
}

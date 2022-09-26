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
    public class CloseFriendRelationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CloseFriendRelationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CloseFriendRelations
        public async Task<IActionResult> Index()
        {
              return View(await _context.CloseFriendRelation.ToListAsync());
        }

        // GET: CloseFriendRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CloseFriendRelation == null)
            {
                return NotFound();
            }

            var closeFriendRelation = await _context.CloseFriendRelation
                .FirstOrDefaultAsync(m => m.CloseFriendRelationId == id);
            if (closeFriendRelation == null)
            {
                return NotFound();
            }

            return View(closeFriendRelation);
        }
        public IActionResult Error()
        {
            return View();
        }
        // GET: CloseFriendRelations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CloseFriendRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CloseFriendRelationId,CloseUserEmail,CloseFriendEmail")] CloseFriendRelation closeFriendRelation)
        {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=aspnet-ASPNetSocialMedia-2E74CB14-DD3A-4442-9DCF-EC4C63E8F3F6; Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [dbo].[AspNetUsers] WHERE [Email] = '" + closeFriendRelation.CloseFriendEmail + "'", con);
            check_User_Name.Parameters.AddWithValue("@user", closeFriendRelation.CloseUserEmail);
            Console.Write(closeFriendRelation.CloseUserEmail);

            int UserExist = (int)check_User_Name.ExecuteScalar();

            if (UserExist > 0)
            {
                con.Close();
                if (ModelState.IsValid)
                {
                    _context.Add(closeFriendRelation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(closeFriendRelation);
            }
            else
            {
                Console.WriteLine("Error, user doesn't exist");
                con.Close();
                ViewData["Success"] = "No user with this email is registered";
                return View(closeFriendRelation);
            }
        }

        // POST: CloseFriendRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CloseFriendRelationId,CloseUserEmail,CloseFriendEmail")] CloseFriendRelation closeFriendRelation)
        {
            if (id != closeFriendRelation.CloseFriendRelationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(closeFriendRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CloseFriendRelationExists(closeFriendRelation.CloseFriendRelationId))
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
            return View(closeFriendRelation);
        }

        // GET: CloseFriendRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CloseFriendRelation == null)
            {
                return NotFound();
            }

            var closeFriendRelation = await _context.CloseFriendRelation
                .FirstOrDefaultAsync(m => m.CloseFriendRelationId == id);
            if (closeFriendRelation == null)
            {
                return NotFound();
            }

            return View(closeFriendRelation);
        }

        // POST: CloseFriendRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CloseFriendRelation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.CloseFriendRelation'  is null.");
            }
            var closeFriendRelation = await _context.CloseFriendRelation.FindAsync(id);
            if (closeFriendRelation != null)
            {
                _context.CloseFriendRelation.Remove(closeFriendRelation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CloseFriendRelationExists(int id)
        {
          return _context.CloseFriendRelation.Any(e => e.CloseFriendRelationId == id);
        }
    }
}

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
    public class FriendRelationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FriendRelationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FriendRelations
        public async Task<IActionResult> Index()
        {
              return View(await _context.FriendRelation.ToListAsync());
        }

        // GET: FriendRelations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FriendRelation == null)
            {
                return NotFound();
            }

            var friendRelation = await _context.FriendRelation
                .FirstOrDefaultAsync(m => m.FriendRelationId == id);
            if (friendRelation == null)
            {
                return NotFound();
            }

            return View(friendRelation);
        }

        public IActionResult Error()
        {
            return View();
        }
        // GET: FriendRelations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FriendRelations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendRelationId,UserEmail,FriendEmail")] FriendRelation friendRelation)
        {
            SqlConnection con = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; Database=aspnet-ASPNetSocialMedia-2E74CB14-DD3A-4442-9DCF-EC4C63E8F3F6; Integrated Security=True");
            con.Open();
            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM [dbo].[AspNetUsers] WHERE [Email] = '"+friendRelation.FriendEmail+"'", con);
            check_User_Name.Parameters.AddWithValue("@user", friendRelation.UserEmail);
            Console.Write(friendRelation.UserEmail);
                
            int UserExist = (int)check_User_Name.ExecuteScalar();

            if (UserExist > 0)
            {
                con.Close();
                if (ModelState.IsValid)
                {
                    _context.Add(friendRelation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               
                return View(friendRelation);
            }
            else
            {
                Console.WriteLine("Error, user doesn't exist");
                con.Close();
                ViewData["Success"] = "No user with this email is registered";
                return View(friendRelation);
            }
            





        }

        // GET: FriendRelations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FriendRelation == null)
            {
                return NotFound();
            }

            var friendRelation = await _context.FriendRelation.FindAsync(id);
            if (friendRelation == null)
            {
                return NotFound();
            }
            return View(friendRelation);
        }

        // POST: FriendRelations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FriendRelationId,UserEmail,FriendEmail")] FriendRelation friendRelation)
        {
            if (id != friendRelation.FriendRelationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friendRelation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendRelationExists(friendRelation.FriendRelationId))
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
            return View(friendRelation);
        }

        // GET: FriendRelations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FriendRelation == null)
            {
                return NotFound();
            }

            var friendRelation = await _context.FriendRelation
                .FirstOrDefaultAsync(m => m.FriendRelationId == id);
            if (friendRelation == null)
            {
                return NotFound();
            }

            return View(friendRelation);
        }

        // POST: FriendRelations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FriendRelation == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FriendRelation'  is null.");
            }
            var friendRelation = await _context.FriendRelation.FindAsync(id);
            if (friendRelation != null)
            {
                _context.FriendRelation.Remove(friendRelation);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendRelationExists(int id)
        {
          return _context.FriendRelation.Any(e => e.FriendRelationId == id);
        }
    }
}

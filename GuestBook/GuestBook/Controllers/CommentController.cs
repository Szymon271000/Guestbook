using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBook.Models;

namespace GuestBook.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentDbContext _context;

        public CommentController(CommentDbContext context)
        {
            _context = context;
        }

        // GET: Comment
        public async Task<IActionResult> Index()
        {
            return _context.Comments != null ?
                          View(await _context.Comments.OrderByDescending(x=> x.CreatedDate).ToListAsync()) :
                          Problem("Entity set 'CommentDbContext.Comments'  is null.");
        }

        // GET: Comment/Details/5

        // GET: Comment/AddOrEdit
        public IActionResult AddOrEdit(int id = 0)
        {
            if(id== 0)
                return View(new Comment());
            else
                return View(_context.Comments.Find(id));
        }

        // POST: Comment/AddOrEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Email,Description,CreatedDate")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                if (comment.Id == 0)
                {
                    comment.CreatedDate = DateTime.Now;
                    _context.Add(comment);
                }
                else
                {
                    _context.Update(comment);
                    comment.CreatedDate = DateTime.Now;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'CommentDbContext.Comments'  is null.");
            }
            var comment = await _context.Comments.FindAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

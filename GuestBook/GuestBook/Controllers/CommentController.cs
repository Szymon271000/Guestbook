using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GuestBook.Models;
using GuestBook.Data;

namespace GuestBook.Controllers
{
    public class CommentController : Controller
    {

        private IBaseRepository<Comment> _repository;

        public CommentController(IBaseRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 5;
            return View(await _repository.GetPage(pageNumber??1, pageSize));
        }

        // GET: Comment/Details/5

        // GET: Comment/AddOrEdit
        public async Task <IActionResult> AddOrEdit(int id = 0)
        {
            if(id== 0)
                return View(new Comment());
            else
                return View(await _repository.GetById(id));
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
                    await _repository.Add(comment);
                }
                else
                {
                    await _repository.Update(comment);                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }



        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _repository.GetById(id);
            if (comment != null)
            {
                _repository.Delete(comment);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

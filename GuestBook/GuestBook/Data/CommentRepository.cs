using GuestBook.Controllers;
using GuestBook.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestBook.Data
{
    public class CommentRepository : IBaseRepository<Comment>
    {
        private readonly CommentDbContext _context;

        public CommentRepository(CommentDbContext context)
        {
            _context = context;
        }
        public async Task Add(Comment entity)
        {
            entity.CreatedDate = DateTime.Now;
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Comment entity)
        {
            _context.Comments.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Comment> GetById(int id)
        {
            return _context.Comments.FirstOrDefaultAsync(x=> x.Id == id);
        }

        public async Task<PaginatedList<Comment>> GetPage(int pageNumber, int pageSize)
        {
            var comments = from comment in _context.Comments
                           select comment;
            return await PaginatedList<Comment>.CreateAsync(comments.OrderByDescending(x => x.CreatedDate).AsNoTracking(), pageNumber , pageSize);

        }

        public async Task Update(Comment entity)
        {
            entity.CreatedDate = DateTime.Now;
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}

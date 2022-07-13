using GuestBook.Controllers;

namespace GuestBook.Data
{
    public interface IBaseRepository<T> where T : class
    {
        public Task Add(T entity);
        public Task Update(T entity);
        public Task Delete(T entity);
        public Task<T> GetById(int id);

        public Task<PaginatedList<T>> GetPage(int pageNumber, int pageSize);
    }
}

using Microsoft.EntityFrameworkCore;
using WebAPIToDo.Data;
using WebAPIToDo.Models;

namespace WebAPIToDo.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;
        public ToDoRepository(ToDoContext context) => this._context = context;
        public async Task AddAsync(ToDoItem item)
        {
            await _context.ToDoItems.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.ToDoItems.FindAsync(id);
            if (item != null)
            {
                _context.ToDoItems.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _context.ToDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            _context.ToDoItems.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}

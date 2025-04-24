using WebAPIToDo.Models;

namespace WebAPIToDo.Services
{
    public interface IToDoService
    {
        Task<IEnumerable<ToDoItem>> GetAllAsync();
        Task<ToDoItem> GetByIdAsync(int id);
        Task AddAsync(ToDoItem item);
        Task UpdateAsync(ToDoItem item);
        Task DeleteAsync(int id);
    }
}

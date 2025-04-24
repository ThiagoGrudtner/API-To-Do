using WebAPIToDo.Models;
using WebAPIToDo.Repositories;

namespace WebAPIToDo.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _repository;
        public ToDoService(IToDoRepository repository) => _repository = repository;
        public async Task AddAsync(ToDoItem item)
        {
            await _repository.AddAsync(item);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<ToDoItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ToDoItem item)
        {
            await _repository.UpdateAsync(item);
        }
    }
}

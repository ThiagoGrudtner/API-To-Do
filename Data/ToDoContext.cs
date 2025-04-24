using Microsoft.EntityFrameworkCore;
using WebAPIToDo.Models;

namespace WebAPIToDo.Data
{
    public class ToDoContext : DbContext
    {
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }
    }
}

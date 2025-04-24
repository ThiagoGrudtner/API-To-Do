using Microsoft.AspNetCore.Mvc;
using WebAPIToDo.Models;
using WebAPIToDo.Services;

namespace WebAPIToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _service;
        public ToDoController(IToDoService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> Get()
        {
            return Ok(await _service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> Get(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ToDoItem item)
        {
            await _service.AddAsync(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(item);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

    }

}

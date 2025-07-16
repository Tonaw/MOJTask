using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOJTask.Data;
using MOJTask.Models;

namespace MOJTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksAPIController : ControllerBase
    {
        private readonly MOJTaskDbContext _context;

        public TasksAPIController(MOJTaskDbContext context)
        {
            _context = context;
        }

        [HttpPost("initialise")]
        public IActionResult Initialise()
        {
            _context.Initialise();
            return Ok(new { message = "Database initialised." });
        }

        /// <summary>
        /// Get a single MOJ task by ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {id} not found." });
            }

            return Ok(task);
        }

        /// <summary>
        /// Get all MOJ tasks
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return Ok(tasks);
        }

        /// <summary>
        /// Update the status of a MOJ task
        /// </summary>
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateTaskStatus(int id, [FromBody] string newStatus)
        {
            if (string.IsNullOrWhiteSpace(newStatus))
            {
                return BadRequest(new { message = "Status cannot be empty." });
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {id} not found." });
            }

            task.Status = newStatus;
            await _context.SaveChangesAsync();

            return Ok(task);
        }

        /// <summary>
        /// Delete a MOJ task
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound(new { message = $"Task with ID {id} not found." });
            }

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Task with ID {id} deleted." });
        }

        /// <summary>
        /// Create a new MOJ task
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CaseWorkerTask newTask)
        {
            if (newTask == null)
            {
                return BadRequest(new { message = "Task data is required." });
            }

            // Validate required fields manually if needed
            if (string.IsNullOrWhiteSpace(newTask.Title) || string.IsNullOrWhiteSpace(newTask.Status))
            {
                return BadRequest(new { message = "Title and Status are required fields." });
            }

            if (newTask.DueDate == default)
            {
                return BadRequest(new { message = "Due date is required." });
            }

            _context.Tasks.Add(newTask);
            await _context.SaveChangesAsync();

            // Return 201 with location header
            return CreatedAtAction(nameof(GetTask), new { id = newTask.Id }, newTask);
        }
    }
}

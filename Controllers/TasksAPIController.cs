using Microsoft.AspNetCore.Mvc;
using MOJTask.Data;

namespace MOJTask.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class TasksAPIController : BaseController
    {
        private readonly MOJTaskDbContext _context;

        public TasksAPIController(MOJTaskDbContext context)
        {
            _context = context;
        }

        public void Initialise()
        {
            _context.Initialise();
        }

        //For API => Get Task details
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

        
    }
}

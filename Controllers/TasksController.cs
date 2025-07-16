using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOJTask.Data;
using MOJTask.Models;
using System.Linq;
using System.Threading.Tasks;


namespace MOJTask.Controllers
{

    //[ApiController]
    //[Route("api/[controller]")]
    public class TasksController : BaseController
    {
        private readonly MOJTaskDbContext _context;

        public void Initialise()
        {
            _context.Initialise();
        }

        public TasksController(MOJTaskDbContext context)
        {
            _context = context;
        }

        //Return all tasks
        public async Task<IActionResult> Index() => View(await _context.Tasks.ToListAsync());
        

        public async Task<IActionResult> Details(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            return task == null ? NotFound() : View(task);
        }


        //For API => Get Task details
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetTask(int id)
        //{
        //    var task = await _context.Tasks.FindAsync(id);
        //    if (task == null)
        //    {
        //        return NotFound(new { message = $"Task with ID {id} not found." });
        //    }

        //    return Ok(task);
        //}

        public IActionResult Create() => View();

        // Create POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Status,DueDate")] CaseWorkerTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);  // Return the view with validation errors
        }

        // Edit GET
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // Edit POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,DueDate")] CaseWorkerTask task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);  // Return the view with validation errors
        }

        // Delete GET
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }

        // Delete POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }

}

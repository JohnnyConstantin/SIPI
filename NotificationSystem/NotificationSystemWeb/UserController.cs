#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificationSystemWeb.Data;
using NotificationSystemWeb.Models;

namespace NotificationSystemWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stack>>> GetStacks()
        {
            return await _context.Stacks.ToListAsync();
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stack>> GetStack(int id)
        {
            var stack = await _context.Stacks.FindAsync(id);

            if (stack == null)
            {
                return NotFound();
            }

            return stack;
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStack(int id, Stack stack)
        {
            if (id != stack.Id)
            {
                return BadRequest();
            }

            _context.Entry(stack).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StackExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<Stack>> PostStack(Stack stack)
        {
            _context.Stacks.Add(stack);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStack", new { id = stack.Id }, stack);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStack(int id)
        {
            var stack = await _context.Stacks.FindAsync(id);
            if (stack == null)
            {
                return NotFound();
            }

            _context.Stacks.Remove(stack);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StackExists(int id)
        {
            return _context.Stacks.Any(e => e.Id == id);
        }
    }
}

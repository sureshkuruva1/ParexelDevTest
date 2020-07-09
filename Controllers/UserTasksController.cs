using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParexelDevTest.DataBase;

namespace ParexelDevTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTasksController : ControllerBase
    {
        private readonly ParaxolDatabaseContext _context;

        public UserTasksController(ParaxolDatabaseContext context)
        {
            _context = context;
        }

        // GET: api/UserTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetUserTask()
        {
          
            var userList = await _context.UserTask.ToListAsync();
            return userList;
        }

        // GET: api/UserTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserTask>> GetUserTask(int id)
        {
            var userTask = await _context.UserTask.FindAsync(id);

            

            if (userTask == null)
            {
                return NotFound();
            }

            return userTask;
        }

        // PUT: api/UserTasks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserTask(int id, UserTask userTask)
        {
            if (id != userTask.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(userTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserTaskExists(id))
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

        // POST: api/UserTasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserTask>> PostUserTask(UserTask userTask)
        {
            _context.UserTask.Add(userTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserTask", new { id = userTask.TaskId }, userTask);
        }

        // DELETE: api/UserTasks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> DeleteUserTask(int id)
        {
            var userTask = await _context.UserTask.FindAsync(id);
            if (userTask == null)
            {
                return NotFound();
            }

            _context.UserTask.Remove(userTask);
            await _context.SaveChangesAsync();

            return await _context.UserTask.ToListAsync();
        }

        private bool UserTaskExists(int id)
        {
            return _context.UserTask.Any(e => e.TaskId == id);
        }
    }
}

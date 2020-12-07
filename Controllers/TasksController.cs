using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Net5Api.Data;
using Net5Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Net5Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TasksDbContext context;

        public TasksController(TasksDbContext context)
        {
            this.context = context;
        }

        [HttpGet("test")]
        public ActionResult TestTasks()
        {
            return Ok("controller is working");
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Task>>> GetTasks()
        {
            var data = await context.Tasks.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTask(MyTask task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("model not matching requirements");
            }

            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
            return Ok("Succesfully created task");
        }

   
        [HttpDelete]
        public async Task<ActionResult> DeleteTask(int id)
        {
            var taskToDelete = await context.Tasks.SingleOrDefaultAsync(x => x.Id == id);

            if(taskToDelete == null)
            {
                return BadRequest("Task Not found");
            }

            context.Remove(taskToDelete);
            await context.SaveChangesAsync();
            return Ok("Succesfully Deleted Task");
        }
    }
}

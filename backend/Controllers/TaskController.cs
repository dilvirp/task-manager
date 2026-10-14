using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{

    private readonly List<TaskItem> tasks = new List<TaskItem>
    {
        new TaskItem
          {
              Id = 1,
              Title = "Build my task manager",
              IsCompleted = false
          },

            new TaskItem
            {
                Id = 2,
                Title = "Add to GitHub",
                IsCompleted = true
            }
    };

    [HttpGet()]
    public List<TaskItem> Get()
    {
        return tasks;
    }

    [HttpGet("{id:int}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        foreach (var task in tasks)
        {
            if (task.Id == id)
            {
                return task;
            }
        }
        return NotFound("Error. Please try again later.");
    }
}


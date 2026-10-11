using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{

    [HttpGet()]
    public List<TaskItem> Get()
    {
        var task = new List<TaskItem>
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

        return task;
    }
}


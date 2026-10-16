using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models;
using TaskManager.API.DTOs;
using TaskManager.API.Data;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController : ControllerBase
{
    private readonly TaskDbContext _context;

    public TaskController(TaskDbContext content)
    {
        _context = content;
    }


    [HttpGet()]
    public List<TaskItem> Get()
    {
        return _context.Tasks.ToList();
    }

    [HttpGet("{id:int}")]
    public ActionResult<TaskItem> GetById(int id)
    {
        var task = _context.Tasks.Find(id);

        if (task == null)
        {
            return NotFound("Task not found.");
        }

        return Ok(task);
    }

    [HttpPost()]
    public ActionResult<TaskItem> Create([FromBody] CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Title = request.Title,
            IsCompleted = false
        };

        _context.Tasks.Add(task);

        _context.SaveChanges();

        return CreatedAtAction(
            nameof(GetById),
            new { id = task.Id },
            task
        );

    }

    [HttpPut("{id:int}")]
    public IActionResult Update(int id, [FromBody] UpdateTaskRequest request)
    {
        var task = _context.Tasks.Find(id);

        if (task == null)
        {
            return NotFound("Task not found!");
        }

        task.Title = request.Title;
        task.IsCompleted = request.IsCompleted;


        _context.SaveChanges();

        return Ok(task);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var task = _context.Tasks.Find(id);

        if (task == null)
        {
            return NotFound("Task not found!");
        }

        _context.Tasks.Remove(task);

        _context.SaveChanges();

        return NoContent();
    }
}


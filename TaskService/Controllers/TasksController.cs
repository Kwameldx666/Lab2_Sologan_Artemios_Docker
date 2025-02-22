using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskService.Data;
using TaskService.Models;

namespace TaskService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskDbContext _context;

    public TasksController(TaskDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _context.Tasks.ToListAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        return task == null ? NotFound() : Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TaskItem task)
    {
        if (string.IsNullOrEmpty(task.Title)) return BadRequest("Title is required");

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = task.Id }, task);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TaskItem updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        task.Title = updatedTask.Title;
        task.IsComplete = updatedTask.IsComplete;
        await _context.SaveChangesAsync();
        return Ok(task);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return NotFound();

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
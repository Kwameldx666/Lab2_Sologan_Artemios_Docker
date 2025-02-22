using CategoryService.Data;
using CategoryService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CategoryService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;

    public CategoriesController(CategoryDbContext context, IHttpClientFactory httpClientFactory)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var categories = await _context.Categories.ToListAsync();
        return Ok(categories);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        return category == null ? NotFound() : Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Category category)
    {
        if (string.IsNullOrEmpty(category.Name)) return BadRequest("Name is required");

        var client = _httpClientFactory.CreateClient("TaskService");
        foreach (var taskId in category.TaskIds)
        {
            var response = await client.GetAsync($"api/tasks/{taskId}");
            if (!response.IsSuccessStatusCode) return BadRequest($"Task {taskId} not found");
        }

        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Category updatedCategory)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();

        var client = _httpClientFactory.CreateClient("TaskService");
        foreach (var taskId in updatedCategory.TaskIds)
        {
            var response = await client.GetAsync($"api/tasks/{taskId}");
            if (!response.IsSuccessStatusCode) return BadRequest($"Task {taskId} not found");
        }

        category.Name = updatedCategory.Name;
        category.TaskIds = updatedCategory.TaskIds;
        await _context.SaveChangesAsync();
        return Ok(category);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null) return NotFound();

        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
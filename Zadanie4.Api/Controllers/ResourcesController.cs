using Microsoft.AspNetCore.Mvc;
using Zadanie4.Api.Models;

namespace Zadanie4.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ResourcesController : ControllerBase
{
    private static readonly List<Resource> Resources = new();

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Resources);
    }

    [HttpPost]
    public IActionResult Create(Resource resource)
    {
        resource.Id = Resources.Count + 1;
        Resources.Add(resource);
        return CreatedAtAction(nameof(GetAll), resource);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var resource = Resources.FirstOrDefault(r => r.Id == id);
        if (resource == null)
            return NotFound();

        Resources.Remove(resource);
        return NoContent();
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, Resource updatedResource)
    {
        var resource = Resources.FirstOrDefault(r => r.Id == id);
        if (resource == null)
            return NotFound();

        resource.Name = updatedResource.Name;
        resource.Type = updatedResource.Type;

        return Ok(resource);
    }
}
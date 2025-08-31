using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarea.Api.Contracts;
using Tarea.Api.Data;
using Tarea.Api.Models;
using Tarea.Api.Services;

namespace Tarea.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareaController(ITareaService tareaService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tareaItems = await tareaService.GetAllAsync();

        var response = tareaItems.ConvertAll(x => new TareaResponse(x.Id, x.Nombre, x.EstaCompleta));
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTareaRequest request)
    {
        var tarea = new TareaItem(request.Nombre, request.EstaCompleta);
        await tareaService.CreateAsync(tarea);

        return CreatedAtAction(nameof(Get), new { id = tarea.Id },
            new TareaResponse(tarea.Id, tarea.Nombre, tarea.EstaCompleta));

    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var tarea = await tareaService.GetByIdAsync(id);
        if (tarea is null)
        {
            return NotFound();
        }

        var response = new TareaResponse(tarea.Id, tarea.Nombre, tarea.EstaCompleta);
        return Ok(response);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateTareaRequest request)
    {
        var tarea = new TareaItem(request.Nombre, request.EstaCompleta) { Id = id };
        var updatedTarea = await tareaService.UpdateAsync(id, tarea);
        if (updatedTarea is null)
        {
            return NotFound();
        }

        var response = new TareaResponse(updatedTarea.Id, updatedTarea.Nombre, updatedTarea.EstaCompleta);
        return Ok(response);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await tareaService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent(); // 204 No Content standard response for successful DELETE requests
    }
   
}


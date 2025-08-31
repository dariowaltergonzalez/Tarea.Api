using System;
using Microsoft.EntityFrameworkCore;
using Tarea.Api.Data;
using Tarea.Api.Models;

namespace Tarea.Api.Services;

public class TareaService(TareaDbContext context) : ITareaService
{
    public async Task CreateAsync(TareaItem item)
    {
        context.TareaItems.Add(item);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var tarea = context.TareaItems.Find(id);
        if (tarea is null)
        {
            return false;
        }
        context.TareaItems.Remove(tarea);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<List<TareaItem>> GetAllAsync()
    {
        return await context.TareaItems.ToListAsync();
    }

    public async Task<TareaItem?> GetByIdAsync(int id)
    {
        var tarea = await context.TareaItems.FindAsync(id);
        return tarea;
    }

    public async Task<TareaItem?> UpdateAsync(int id, TareaItem item)
    {
        var existingTarea = await context.TareaItems.FindAsync(id);
        if (existingTarea is null)
        {
            return null;
        }

        existingTarea.Nombre = item.Nombre;
        existingTarea.EstaCompleta = item.EstaCompleta;
        await context.SaveChangesAsync();
        return existingTarea;
    }
}

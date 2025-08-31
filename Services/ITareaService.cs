using System;
using Tarea.Api.Models;

namespace Tarea.Api.Services;

public interface ITareaService
{
    Task<List<TareaItem>> GetAllAsync();
    Task CreateAsync(TareaItem item);
    Task<TareaItem?> GetByIdAsync(int id);
    Task<TareaItem?> UpdateAsync(int id, TareaItem item);
    Task<bool> DeleteAsync(int id);
}

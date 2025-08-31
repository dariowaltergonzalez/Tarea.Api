using System;
using Microsoft.EntityFrameworkCore;
using Tarea.Api.Models;

namespace Tarea.Api.Data;

public class TareaDbContext(DbContextOptions<TareaDbContext> options) : DbContext(options)
{
    public DbSet<TareaItem> TareaItems => Set<TareaItem>();
}

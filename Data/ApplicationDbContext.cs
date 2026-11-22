using IntentaloEnCasa.Models;
using Microsoft.EntityFrameworkCore;

namespace IntentaloEnCasa.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Actividad> Actividades { get; set; } = null!;

    public DbSet<Cita> Citas { get; set; } = null!;
}
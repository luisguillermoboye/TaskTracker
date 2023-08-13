using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Entities;

namespace TaskTracker.Data.Context
{
    public interface ITaskTrackerDbContext
    {
        DbSet<ColorPersonal> Colores { get; set; }
        DbSet<ImagenPerfil> ImagenesPerfil { get; set; }
        DbSet<Paso> Pasos { get; set; }
        DbSet<Tarea> Tareas { get; set; }
        DbSet<Usuario> Usuarios { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
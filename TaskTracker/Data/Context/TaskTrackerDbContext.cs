using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Entities;

namespace TaskTracker.Data.Context
{
    public class TaskTrackerDbContext : DbContext, ITaskTrackerDbContext
    {
        private readonly IConfiguration config;
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ColorPersonal> Colores { get; set; }

        public DbSet<Paso> Pasos { get; set; }

        public DbSet<ImagenPerfil> ImagenesPerfil { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TaskTrackerDbContext(IConfiguration config)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.ListaTareas)
                .WithOne(p => p.Usuario).OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Tarea>()
                .HasMany(t => t.ListaPasos)
                .WithOne(p => p.Tarea).OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}

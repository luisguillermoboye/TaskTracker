using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Entities
{
    public class Tarea
    {

        [Key]
        public int IdTarea { get; set; }

        [StringLength(25)]
        public string NombreTarea { get; set; } = null!;

        [StringLength(60)]
        public string Descripcion { get; set; } = null!;
        public int CantidadPasos { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int IdUsuario { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public virtual List<Paso> ListaPasos { get; set; }
        public bool Completada { get; set; }
        public string? Icono { get; set; } = null!;

        public virtual Usuario Usuario {get; set;}


        public static Tarea Crear(TareaRequest tarea) => new Tarea
        {
            IdTarea = tarea.IdTarea,
            NombreTarea = tarea.NombreTarea,
            Descripcion = tarea.Descripcion,
            CantidadPasos = tarea.CantidadPasos,
            FechaCreacion = tarea.FechaCreacion, // Set appropriate value for FechaCreacion
            IdUsuario = tarea.IdUsuario,
            FechaFinalizacion = tarea.FechaFinalizacion, // Set appropriate value for FechaFinalizacion
            ListaPasos = tarea.ListaPasos, // Set appropriate value for ListaPasos
            Completada = tarea.Completada, // Set appropriate value for Completada
            Icono = tarea.Icono // Set appropriate value for Icono
        };

        public bool Modificar(TareaRequest tarea)
        {
            var cambio = false;
            if (NombreTarea != tarea.NombreTarea)
            {
                NombreTarea = tarea.NombreTarea;
                cambio = true;
            }

            if (Descripcion != tarea.Descripcion)
            {
                Descripcion = tarea.Descripcion;
                cambio = true;
            }

            if (CantidadPasos != tarea.CantidadPasos)
            {
                CantidadPasos = tarea.CantidadPasos;
                cambio = true;
            }

            if (FechaCreacion != tarea.FechaCreacion)
            {
                FechaCreacion = tarea.FechaCreacion;
                cambio = true;
            }

            if (IdUsuario != tarea.IdUsuario)
            {
                IdUsuario = tarea.IdUsuario;
                cambio = true;
            }

            if (FechaFinalizacion != tarea.FechaFinalizacion)
            {
                FechaFinalizacion = tarea.FechaFinalizacion;
                cambio = true;
            }

            if (Icono != tarea.Icono)
            {
                Icono = tarea.Icono;
                cambio = true;
            }

            return cambio;
        }


        public TareaResponse ToResponse() => new()
        {
            IdTarea = IdTarea,
            NombreTarea = NombreTarea,
            Descripcion = Descripcion,
            CantidadPasos = CantidadPasos,
            FechaCreacion = FechaCreacion,
            IdUsuario = IdUsuario,
            FechaFinalizacion = FechaFinalizacion,
            ListaPasos = ListaPasos,
            Completada = Completada,
            Icono = Icono

        };
    }


}

using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;

namespace TaskTracker.Data.Response
{
    public class TareaResponse
    {
        public int IdTarea { get; set; }

       
        public string NombreTarea { get; set; } = null!;

      
        public string Descripcion { get; set; } = null!;
        public int CantidadPasos { get; set; }
        public DateTime FechaCreacion { get; set; }

        public int IdUsuario { get; set; }
        public DateTime? FechaFinalizacion { get; set; }
        public virtual List<Paso> ListaPasos { get; set; }
        public bool Completada { get; set; }
        public string? Icono { get; set; } = null!;



        public TareaRequest ToRequest() => new()
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

using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Request;

namespace TaskTracker.Data.Response
{
    public class PasoResponse
    {
        public int IdPaso { get; set; }
        public string NombrePaso { get; set; } = null!;
        public int NumeroPaso { get; set; }
        public int IdTarea { get; set; }
        public bool Hecho { get; set; }
        public int IdUsuario { get; set; }
        public string Descripcion { get; set; } = null!;



        public PasoRequest ToRequest() => new()
        {
            IdPaso = IdPaso,
            NombrePaso = NombrePaso,
            NumeroPaso = NumeroPaso,
            IdTarea = IdTarea,
            Hecho = Hecho,
            Descripcion = Descripcion,
            IdUsuario = IdUsuario

        };
    }
}

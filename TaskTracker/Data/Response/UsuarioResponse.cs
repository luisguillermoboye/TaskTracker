using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;
using static MudBlazor.CategoryTypes;

namespace TaskTracker.Data.Response
{
    public class UsuarioResponse
    {
        public int IdUsuario { get; set; }


        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }
        public virtual List<Tarea> ListaTareas { get; set; }
        public virtual ImagenPerfil ImagenPerfil { get; set; } 
        public virtual ColorPersonal ColorPersonal { get; set; }
        public virtual List<Paso> ListaPasos { get; set; }


        public UsuarioRequest ToRequest() => new()
        {
            IdUsuario = IdUsuario,
            NombreUsuario = NombreUsuario,
            Clave = Clave,
            FechaCreacion = FechaCreacion,
            ListaTareas = ListaTareas,
            ListaPasos = ListaPasos,
            ColorPersonal = ColorPersonal,
            ImagenPerfil = ImagenPerfil

        };
    }


    
}

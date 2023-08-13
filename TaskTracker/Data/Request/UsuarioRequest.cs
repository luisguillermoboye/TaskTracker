using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TaskTracker.Data.Entities;

namespace TaskTracker.Data.Request
{
    public class UsuarioRequest
    {
        public int IdUsuario { get; set; }

        [Required]
        

        public string NombreUsuario { get; set; } = null!;

        
        public string Clave { get; set; } = null!;


        [Required]
       
        public string Correo { get; set; } = null!;


        [Required]
        public DateTime FechaCreacion { get; set; }
        public virtual List<Tarea> ListaTareas { get; set; }
        public virtual ImagenPerfil ImagenPerfil { get; set; }
        public virtual ColorPersonal ColorPersonal { get; set; }
        public virtual List<Paso> ListaPasos { get; set; }
    }
}

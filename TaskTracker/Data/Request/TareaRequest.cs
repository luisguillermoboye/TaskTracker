using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Entities;

namespace TaskTracker.Data.Request
{
    public class TareaRequest
    {
        public int IdTarea { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre la tarea")]
        [Display(Name = "NombreTarea")]
        public string NombreTarea { get; set; } = null!;

        [Required(ErrorMessage = "Ingrese una descripcion para el paso")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;

        [Required]
        
        public int CantidadPasos { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        public DateTime? FechaFinalizacion { get; set; }
        public virtual List<Paso> ListaPasos { get; set; }


        [Required]
        public bool Completada { get; set; }

        [Required(ErrorMessage = "Ingrese un ícono")]
        [Display(Name = "Icono")]
        public string? Icono { get; set; } = null!;
    }
}

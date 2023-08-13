using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Data.Request
{
    public class PasoRequest
    {
        public int IdPaso { get; set; }


        [Required(ErrorMessage = "Ingrese un nombre para el paso")]
        [Display(Name = "NombrePaso")]
        public string NombrePaso { get; set; } = null!;


        [Required]
       
        public int NumeroPaso { get; set; }

        [Required]
      
        public int IdTarea { get; set; }

        [Required]
        
        public bool Hecho { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Introduzca una descripción para el paso")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; } = null!;
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TaskTracker.Data.Request
{
    public class ColorPersonalRequest
    {

        public int IdColor { get; set; }


        [Required(ErrorMessage = "Elija un color")]
        [Display(Name = "Color")]
        public string CodigoColor { get; set; } = null!;

        [Required]
        public int IdUsuario { get; set; }
    }
}

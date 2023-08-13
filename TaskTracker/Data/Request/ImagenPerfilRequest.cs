using System.ComponentModel.DataAnnotations;

namespace TaskTracker.Data.Request
{
    public class ImagenPerfilRequest
    {
        public int IdImagen { get; set; }
        public string? ImagenUrl { get; set; }
        public byte[]? ImagenMap { get; set; }

        [Required(ErrorMessage = "Elija un color")]
        public int IdUsuario { get; set; }
    }
}

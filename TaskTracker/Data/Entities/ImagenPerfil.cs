using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Entities
{
    public class ImagenPerfil
    {
        [Key]
        public int IdImagen { get; set; }
        public string? ImagenUrl { get; set; } 
        public byte[]? ImagenMap { get; set; }
        public int IdUsuario { get; set; }

        


        public static ImagenPerfil Crear(ImagenPerfilRequest imagenPerfil)
        {
            return new ImagenPerfil
            {
                IdImagen = imagenPerfil.IdImagen,
                ImagenUrl = imagenPerfil.ImagenUrl,
                ImagenMap = imagenPerfil.ImagenMap,
                IdUsuario = imagenPerfil.IdUsuario
            };
        }

        public bool Modificar(ImagenPerfilRequest imagenPerfil)
        {
            var cambio = false;
            if (ImagenUrl != imagenPerfil.ImagenUrl)
            {
                ImagenUrl = imagenPerfil.ImagenUrl;
                cambio = true;
            }

            if (!ImagenMap?.SequenceEqual(imagenPerfil.ImagenMap) ?? false)
            {
                ImagenMap = imagenPerfil.ImagenMap;
                cambio = true;
            }

            return cambio;
        }

        public ImagenPerfilResponse ToResponse() => new ()
        {
            IdImagen = IdImagen,
            ImagenUrl = ImagenUrl,
            ImagenMap = ImagenMap,
            IdUsuario = IdUsuario
        };
    }


}

using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Entities
{
    public class ColorPersonal
    {
        [Key]
        public int IdColor { get; set; }
        public string CodigoColor { get; set; } = null!;
        public int IdUsuario { get; set; }

        public static ColorPersonal Crear(ColorPersonalRequest colorPersonal)
        {
            return new ColorPersonal
            {
                IdColor = colorPersonal.IdColor,
                CodigoColor = colorPersonal.CodigoColor,
                IdUsuario = colorPersonal.IdUsuario
            };
        }

        public bool Modificar(ColorPersonalRequest colorPersonal)
        {
            var cambio = false;
            if (CodigoColor != colorPersonal.CodigoColor)
            {
                CodigoColor = colorPersonal.CodigoColor;
                cambio = true;
            }

            return cambio;
        }

        public ColorPersonalResponse ToResponse() => new ()
        {
            IdColor = IdColor,
            CodigoColor = CodigoColor,
            IdUsuario = IdUsuario
        };



    }


}

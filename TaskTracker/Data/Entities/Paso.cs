using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Entities
{
    public class Paso
    {
        [Key]
        public int IdPaso { get; set; }


        [StringLength(25)]
        public string NombrePaso { get; set; } = null!;
        public int NumeroPaso { get; set; }
        public int IdTarea { get; set; }
        public bool Hecho { get; set; }
        public int IdUsuario { get; set; }

        [StringLength(60)]
        public string Descripcion { get; set; } = null!;

        public virtual Tarea Tarea { get; set; }   


        public static Paso Crear(PasoRequest paso) => new()
        {


            IdPaso = paso.IdPaso,
            NombrePaso = paso.NombrePaso,
            NumeroPaso = paso.NumeroPaso,
            IdTarea = paso.IdTarea,
            Hecho = paso.Hecho,
            IdUsuario = paso.IdUsuario,
            Descripcion = paso.Descripcion

        };
        public bool Modificar(PasoRequest paso)
        {
            var cambio = false;
            if (NombrePaso != paso.NombrePaso)
            {
                NombrePaso = paso.NombrePaso;
                cambio = true;
            }

            if (Descripcion != paso.Descripcion)
            {
                Descripcion = paso.Descripcion;
                cambio = true;
            }

            if (NumeroPaso != paso.NumeroPaso)
            {
                NumeroPaso = paso.NumeroPaso;
                cambio = true;
            }

            if (IdTarea != paso.IdTarea)
            {
                IdTarea = paso.IdTarea;
                cambio = true;
            }

            if (IdUsuario != paso.IdUsuario)
            {
                IdUsuario = paso.IdUsuario;
                cambio = true;
            }

            if (Hecho != paso.Hecho)
            {
                Hecho = paso.Hecho;
                cambio = true;
            }

            return cambio;
        }

        
        public PasoResponse ToResponse() => new ()
        {
            IdPaso = IdPaso,
            NombrePaso = NombrePaso,
            NumeroPaso = NumeroPaso,
            IdTarea = IdTarea,
            Hecho = Hecho,
            IdUsuario = IdUsuario,
            Descripcion = Descripcion
        };
    }


}

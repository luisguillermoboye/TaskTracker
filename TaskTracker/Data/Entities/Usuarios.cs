using System.ComponentModel.DataAnnotations;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Entities
{
    public class Usuario
    {

        [Key]
        
        public int IdUsuario { get; set; }

        
        public string NombreUsuario { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }
        public virtual List<Tarea> ListaTareas { get; set; }
        public virtual ImagenPerfil ImagenPerfil { get; set; }
        public virtual ColorPersonal ColorPersonal { get; set; }
        public virtual List<Paso> ListaPasos { get; set; }


        public static Usuario Crear(UsuarioRequest usuario) => new()
        {


            IdUsuario = usuario.IdUsuario,
            NombreUsuario = usuario.NombreUsuario,
            Clave = usuario.Clave,
            Correo = usuario.Correo,
            FechaCreacion = usuario.FechaCreacion, // Set appropriate value for FechaCreacion
            ListaTareas = usuario.ListaTareas, // You can set the list or leave it empty based on your requirements
            ImagenPerfil = usuario.ImagenPerfil, // Set appropriate value for ImagenPerfil
            ColorPersonal = usuario.ColorPersonal, // Set appropriate value for ColorPersonal
            ListaPasos = usuario.ListaPasos // You can set the list or leave it empty based on your requirements

        };

       
        
            // Properties as defined earlier

            public bool Modificar(UsuarioRequest usuario)
            {
                var cambio = false;
                if (NombreUsuario != usuario.NombreUsuario)
                {
                    NombreUsuario = usuario.NombreUsuario;
                    cambio = true;
                }

                if (Clave != usuario.Clave)
                {
                    Clave = usuario.Clave;
                    cambio = true;
                }

                if (Correo != usuario.Correo)
                {
                    Correo = usuario.Correo;
                    cambio = true;
                }

                if (FechaCreacion != usuario.FechaCreacion)
                {
                    FechaCreacion = usuario.FechaCreacion;
                    cambio = true;
                }

                

                return cambio;
            }
        

       
        public UsuarioResponse ToResponse() => new UsuarioResponse
        {
            IdUsuario = IdUsuario,
            NombreUsuario = NombreUsuario,
            Clave = Clave,
            Correo = Correo,
            FechaCreacion = FechaCreacion,
            ListaTareas = ListaTareas,
            ImagenPerfil = ImagenPerfil,
            ColorPersonal = ColorPersonal,
            ListaPasos = ListaPasos
            // You can add other properties to be included in the response as needed
        };
    }

   
    



}




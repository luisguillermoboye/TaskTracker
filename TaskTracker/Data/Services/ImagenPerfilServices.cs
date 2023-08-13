using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public class ImagenPerfilServices : IImagenPerfilServices
    {
        private readonly ITaskTrackerDbContext dbContext;

        public ImagenPerfilServices(ITaskTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(ImagenPerfilRequest request)
        {
            try
            {
                var imagen = ImagenPerfil.Crear(request);
                dbContext.ImagenesPerfil.Add(imagen);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Se guardó el paso", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(ImagenPerfilRequest request)
        {
            try
            {
                var imagen = await dbContext.ImagenesPerfil
                    .FirstOrDefaultAsync(p => p.IdImagen == request.IdImagen);
                if (imagen == null)
                    return new Result() { Message = "No se encontro la tarea", Success = false };

                if (imagen.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<ImagenPerfilResponse>> Consultar(int id)
        {

            try
            {
                var imagen = await dbContext.ImagenesPerfil
                     .FirstOrDefaultAsync(i =>
                         i.IdUsuario == id);








                return new Result<ImagenPerfilResponse>()
                {

                    Message = "Ok",
                    Success = true,
                    Data = imagen.ToResponse()
                };
            }
            catch (Exception E)
            {
                return new Result<ImagenPerfilResponse>
                {
                    Message = E.Message,
                    Success = false
                };
            }





        }
    }
}

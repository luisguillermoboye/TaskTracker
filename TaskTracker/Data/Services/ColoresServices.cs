using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public class ColoresServices : IColoresServices
    {
        private readonly ITaskTrackerDbContext dbContext;

        public ColoresServices(ITaskTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(ColorPersonalRequest request)
        {
            try
            {
                var color = ColorPersonal.Crear(request);
                dbContext.Colores.Add(color);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Se guardo el color", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result> Modificar(ColorPersonalRequest request)
        {
            try
            {
                var color = await dbContext.Colores
                    .FirstOrDefaultAsync(c => c.IdColor == request.IdColor);
                if (color == null)

                    return new Result() { Message = "No se encontro el color", Success = false };

                if (color.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Se modificó el color correctamente", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

        public async Task<Result<ColorPersonalResponse>> Consultar(int id)
        {
            try
            {
                var color = await dbContext.Colores
                                          .FirstOrDefaultAsync(c =>
                                               c.IdUsuario == id);




                return new Result<ColorPersonalResponse>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = color.ToResponse()
                };
            }
            catch (Exception E)
            {
                return new Result<ColorPersonalResponse>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}

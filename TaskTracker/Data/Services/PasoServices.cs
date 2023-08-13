using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public class PasoServices : IPasoServices
    {
        private readonly ITaskTrackerDbContext dbContext;

        public PasoServices(ITaskTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(TareaRequest request)
        {
            try
            {
                var tarea = Tarea.Crear(request);
                dbContext.Tareas.Add(tarea);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Se guardó el paso", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(PasoRequest request)
        {
            try
            {
                var paso = await dbContext.Pasos
                    .FirstOrDefaultAsync(p => p.IdPaso == request.IdPaso);
                if (paso == null)
                    return new Result() { Message = "No se encontro la tarea", Success = false };

                if (paso.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(PasoRequest request)
        {
            try
            {
                var paso = await dbContext.Pasos
                    .FirstOrDefaultAsync(p => p.IdPaso == request.IdPaso);
                if (paso == null)
                    return new Result() { Message = "No se encontro la tarea", Success = false };



                dbContext.Pasos.Remove(paso);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<PasoResponse>>> Consultar(int id)
        {
            try
            {
                var pasos = await dbContext.Pasos
                     .Where(p =>
                         p.IdUsuario == id).Select(p => p.ToResponse())
                     .ToListAsync();







                return new Result<List<PasoResponse>>()
                {

                    Message = "Ok",
                    Success = true,
                    Data = pasos
                };
            }
            catch (Exception E)
            {
                return new Result<List<PasoResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}

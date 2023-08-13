using Microsoft.EntityFrameworkCore;
using MudBlazor.Charts;
using TaskTracker.Data.Context;
using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public class TareaServices : ITareaServices
    {
        private readonly ITaskTrackerDbContext dbContext;

        public TareaServices(ITaskTrackerDbContext dbContext)
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
                return new Result() { Message = "Se guardó la tarea", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(TareaRequest request)
        {
            try
            {
                var tarea = await dbContext.Tareas
                    .FirstOrDefaultAsync(t => t.IdTarea == request.IdTarea);
                if (tarea == null)
                    return new Result() { Message = "No se encontro la tarea", Success = false };

                if (tarea.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(TareaRequest request)
        {
            try
            {
                var tarea = await dbContext.Tareas
                    .FirstOrDefaultAsync(t => t.IdTarea == request.IdTarea);
                if (tarea == null)
                    return new Result() { Message = "No se encontro la tarea", Success = false };



                dbContext.Tareas.Remove(tarea);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<TareaResponse>>> Consultar(int id)
        {
            try
            {
                var tareas = await dbContext.Tareas
                     .Where(t =>
                         t.IdUsuario == id).Select(l => l.ToResponse())
                     .ToListAsync();







                return new Result<List<TareaResponse>>()
                {

                    Message = "Ok",
                    Success = true,
                    Data = tareas
                };
            }
            catch (Exception E)
            {
                return new Result<List<TareaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
        public async Task<Result> Hecha(TareaRequest request)
        {
            try
            {
                var tarea = await dbContext.Tareas
                    .FirstOrDefaultAsync(t => t.IdTarea == request.IdTarea);
                var pasos = await dbContext.Pasos
                     .Where(p =>
                         p.IdTarea == tarea.IdTarea).ToListAsync();
                
                if (tarea == null)

                    return new Result() { Message = "No se encontro la tarea", Success = false };

                if (tarea.Modificar(request))
                    dbContext.Pasos.RemoveRange(pasos);
                     await dbContext.SaveChangesAsync();


                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }

    }
}

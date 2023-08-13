using Microsoft.EntityFrameworkCore;
using TaskTracker.Data.Context;
using TaskTracker.Data.Entities;
using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public class UserServices : IUserServices
    {
        private readonly ITaskTrackerDbContext dbContext;

        public UserServices(ITaskTrackerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(UsuarioRequest request)
        {
            try
            {
                var usuario = Usuario.Crear(request);
                dbContext.Usuarios.Add(usuario);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Se registró el usuario", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .FirstOrDefaultAsync(l => l.IdUsuario == request.IdUsuario);
                if (usuario == null)
                    return new Result() { Message = "No se encontro el libro", Success = false };

                if (usuario.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(UsuarioRequest request)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                    .FirstOrDefaultAsync(l => l.IdUsuario == request.IdUsuario);
                if (usuario == null)
                    return new Result() { Message = "No se encontro el Libro", Success = false };



                dbContext.Usuarios.Remove(usuario);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<UsuarioResponse>> Consultar(string correo)
        {
            try
            {
                var usuario = await dbContext.Usuarios
                                          .FirstOrDefaultAsync(u =>
                                              u.Correo == correo);




                return new Result<UsuarioResponse>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = usuario.ToResponse()
                };
            }
            catch (Exception E)
            {
                return new Result<UsuarioResponse>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}


using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public interface IUserServices
    {
        Task<Result<UsuarioResponse>> Consultar(string correo);
        Task<Result> Crear(UsuarioRequest request);
        Task<Result> Eliminar(UsuarioRequest request);
        Task<Result> Modificar(UsuarioRequest request);
    }
}
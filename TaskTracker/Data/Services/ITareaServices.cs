using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public interface ITareaServices
    {
        Task<Result<List<TareaResponse>>> Consultar(int id);
        Task<Result> Crear(TareaRequest request);
        Task<Result> Eliminar(TareaRequest request);
        Task<Result> Modificar(TareaRequest request);
    }
}
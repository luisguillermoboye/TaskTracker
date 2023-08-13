using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public interface IPasoServices
    {
        Task<Result<List<PasoResponse>>> Consultar(int id);
        Task<Result> Crear(TareaRequest request);
        Task<Result> Eliminar(PasoRequest request);
        Task<Result> Modificar(PasoRequest request);
    }
}
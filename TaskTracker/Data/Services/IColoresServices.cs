using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public interface IColoresServices
    {
        Task<Result<ColorPersonalResponse>> Consultar(int id);
        Task<Result> Crear(ColorPersonalRequest request);
        Task<Result> Modificar(ColorPersonalRequest request);
    }
}
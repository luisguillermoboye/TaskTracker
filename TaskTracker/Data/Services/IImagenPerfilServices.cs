using TaskTracker.Data.Request;
using TaskTracker.Data.Response;

namespace TaskTracker.Data.Services
{
    public interface IImagenPerfilServices
    {
        Task<Result<ImagenPerfilResponse>> Consultar(int id);
        Task<Result> Crear(ImagenPerfilRequest request);
        Task<Result> Modificar(ImagenPerfilRequest request);
    }
}
using TaskTracker.Data.Request;

namespace TaskTracker.Data.Response
{
    public class ColorPersonalResponse
    {
        public int IdColor { get; set; }
        public string CodigoColor { get; set; } = null!;
        public int IdUsuario { get; set; }


        public ColorPersonalRequest ToRequest() => new()
        {
            IdColor = IdColor,
            CodigoColor = CodigoColor,
            IdUsuario = IdUsuario
        };
    }
}

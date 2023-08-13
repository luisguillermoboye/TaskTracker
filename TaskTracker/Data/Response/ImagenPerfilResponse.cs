namespace TaskTracker.Data.Response
{
    public class ImagenPerfilResponse
    {
        public int IdImagen { get; set; }
        public string? ImagenUrl { get; set; }
        public byte[]? ImagenMap { get; set; }
        public int IdUsuario { get; set; }


        public ImagenPerfilResponse ToRequest() => new()
        {
            IdImagen = IdImagen,
            ImagenUrl = ImagenUrl,
            ImagenMap = ImagenMap,
            IdUsuario = IdUsuario
        };
    }
}

namespace TaskTracker.Data.Services
{
    public interface ITema
    {
        string Color { get; set; }
        bool ModoNocturno { get; set; }

        bool SetMode();
        bool SetMode(bool estado);
    }
}
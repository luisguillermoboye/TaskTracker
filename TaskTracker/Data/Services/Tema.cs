namespace TaskTracker.Data.Services
{
    public class Tema : ITema
    {
        public string Color { get; set; } = "#1D5B79";
        public bool ModoNocturno { get; set; } = false;


        public bool SetMode()
        {
            DateTime horaActual = DateTime.Now;
            if (horaActual.Hour >= 19)
            {
                this.ModoNocturno = true;
                return ModoNocturno;
            }
            else
            {
                this.ModoNocturno = false;
                return ModoNocturno;
            }
        }
        public bool SetMode(bool estado)
        {
            if (estado)
            {
                this.ModoNocturno = true;
                return ModoNocturno;
            }
            else
            {
                this.ModoNocturno = false;
                return ModoNocturno;
            }
        }
    }
}

using System;

namespace DigitalClock
{
    [Serializable()]
    internal class Alarma
    {
        public string hora { get; set; }
        public bool enable { get; set; }

        public Alarma() { }

        public Alarma(string hora , Boolean enable)
        {
            this.hora = hora;
            this.enable = enable;
        }
    }
}
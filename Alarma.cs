using System;

namespace Reloj
{
    [Serializable()]
    class Alarma
    {
        public string horas { get; set; }
        public string minutos { get; set; }
        public string segundos { get; set; }
        public bool enable { get; set; }

        public Alarma() { }

        public Alarma(string horas, string minutos, string segundos, Boolean enable)
        {
            this.horas = horas;
            this.minutos = minutos;
            this.segundos = segundos;
            this.enable = enable;
        }
    }
}

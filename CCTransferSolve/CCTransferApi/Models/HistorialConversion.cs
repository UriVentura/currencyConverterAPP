using System;

namespace CCTransferApi.Models
{
    public class HistorialConversion
    {
        public int Id { get; set; }
        public string MonedaInicio { get; set; }
        public string MonedaDestino { get; set; }
        public double Importe { get; set; }
        public double Resultado { get; set; }
        public DateTime Fecha { get; set; }
        public string NombreUsuario { get; set; }
    }
}

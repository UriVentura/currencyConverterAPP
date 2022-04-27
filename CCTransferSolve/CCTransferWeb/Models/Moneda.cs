namespace CCTransferWeb.Models
{
    public class Moneda
    {
        public int Id { get; set; }
        public string NomMoneda { get; set; }
        public string CodMoneda { get; set; }
    }

    public class FactorConversion
    {
        public int Id { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double Conversion { get; set; }
    }
}



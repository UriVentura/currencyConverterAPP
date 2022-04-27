using System.ComponentModel.DataAnnotations;

namespace CCTransferB.Models
{
    public class Moneda
    {
        public int Id { get; set; }
        [Required]
        public string NomMoneda { get; set; }
        [Required]
        public string CodMoneda { get; set; }
    }

    public class FactorConversion
    {
        [Key]
        public int Id { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
        public double Conversion { get; set; }
    }
}

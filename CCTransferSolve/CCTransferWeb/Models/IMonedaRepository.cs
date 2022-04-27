using System.Collections.Generic;

namespace CCTransferWeb.Models
{
    public interface IMonedaRepository
    {
        IEnumerable<Moneda> AllMonedas { get; }
        Moneda GetMonedasForId(int Id);
    }
}

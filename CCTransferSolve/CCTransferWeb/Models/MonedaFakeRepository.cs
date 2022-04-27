using System.Collections.Generic;
using System.Linq;

namespace CCTransferWeb.Models

{
    public class MonedaFakeRepository : IMonedaRepository
    {

        public IEnumerable<Moneda> AllMonedas =>
        new List<Moneda> {

                new Moneda{ Id = 1, CodMoneda="EUR", NomMoneda= "Euro"},
        };

        public Moneda GetMonedasForId(int Id)
        {
            return AllMonedas.FirstOrDefault(m => m.Id == Id);
        }
    }
}

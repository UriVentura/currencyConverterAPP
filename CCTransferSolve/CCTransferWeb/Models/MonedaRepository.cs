using System.Collections.Generic;
using System.Linq;
using CCTransferWeb.DbContexts;

namespace CCTransferWeb.Models
{
    public class MonedaRepository : IMonedaRepository
    {
        private readonly CCTransferDbContext _context;

        public MonedaRepository(CCTransferDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Moneda> AllMonedas
        {
            get
            {
                return _context.Monedas;
            }
        }

        public Moneda GetMonedasForId(int Id)
        {
            return _context.Monedas.FirstOrDefault(m=> m.Id == Id);
        }
    }
}

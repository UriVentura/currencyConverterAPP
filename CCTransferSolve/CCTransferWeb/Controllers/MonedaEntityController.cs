using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using CCTransferWeb.DbContexts;
using CCTransferWeb.Models;

namespace CCTransferWeb.Controllers

{
    public class MonedaEntityController : Controller
    {
        private readonly CCTransferDbContext _context;

        public MonedaEntityController(CCTransferDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var moneda1 = new Moneda { NomMoneda = "Boliviano", CodMoneda = "BOB" };
            _context.Add(moneda1);
            _context.SaveChanges();

            var moneda2 = _context.Monedas.FirstOrDefault(m=>m.Id == moneda1.Id);
            moneda2.NomMoneda = "Boliviano (Corregido)";
            _context.Update(moneda2);
            _context.SaveChanges();


            List<Moneda> listMonedas = _context.Monedas.ToList();
            return View(listMonedas);
        }
    }
}

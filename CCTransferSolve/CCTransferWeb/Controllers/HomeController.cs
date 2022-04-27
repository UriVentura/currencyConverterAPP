using FixerSharpCore;
using Microsoft.AspNetCore.Mvc;
using CCTransferWeb.DbContexts;
using CCTransferWeb.Models;
using System;
using System.Linq;

namespace CCTransferWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly CCTransferDbContext _context;

        public HomeController(CCTransferDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            guardarMoneda();
            
            return View();
        }

        public void guardarMoneda()
        {
            //Introducimos la ApiKey
            //Recoger monedas(Código)
            Fixer.SetApiKey("b87417506452f8c09b86e39a3067c156");

            //Recogemos los nombre de las monedas de la api y los guardamos en una variable
            var listaMonedas = Fixer.GetLatestCodesAndValues();

            foreach (var m in listaMonedas)
            {
                //Si encuentra alguno te devuelve el elemento, en caso contrario no te devuelve ninguno
                var valorConversion = _context.Monedas.FirstOrDefault(x => x.CodMoneda.Equals(m.Target));
                var buscarConversion = _context.FactorConversiones.FirstOrDefault(x => x.MonedaOrigen.Equals(m.Base) && x.MonedaDestino.Equals(m.Target));
                //Si en el valor no contiene nigún elemento significa que no hay ese elemento en la base de datos
                //Entonces procedemos a guardar ese nuevo elemento
                if (valorConversion == null)
                { 
                    _context.Add(new Moneda { CodMoneda = m.Target, NomMoneda = m.Target});
                    _context.SaveChanges();
                }
                if (buscarConversion == null)
                {
                    _context.Add(new FactorConversion { MonedaOrigen = m.Base, MonedaDestino = m.Target, Conversion = m.Rate});
                    _context.SaveChanges();
                }
            }
        }
    }
}

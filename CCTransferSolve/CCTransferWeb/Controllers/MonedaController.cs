using CCTransferWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;


namespace CCTransferWeb.Controllers
{
    public class MonedaController : Controller
    {
      
        private readonly IMonedaRepository _monedarepository;

        public MonedaController(IMonedaRepository monedarepository)
        {
            _monedarepository = monedarepository;
        }


        public IActionResult List()
        {
            return View(_monedarepository.AllMonedas);
        }
    }
}

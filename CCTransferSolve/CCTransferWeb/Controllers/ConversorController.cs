using Microsoft.AspNetCore.Mvc;

namespace CCTransferWeb.Controllers
{
    public class ConversorController : Controller
    {
        private readonly IConversor _conversor;

        public ConversorController(IConversor conversor)
        {
            _conversor = conversor;
        }


        // Paso 1 
        public IActionResult EuroDolar(double importe)
        {
            double modeloVista = _conversor.Calcular(importe);
            return View(modeloVista *= 1.10);

        }

        public IActionResult EuroLibra(double importe)
        {
            double modeloVista = _conversor.Calcular(importe);
            return View(modeloVista *= 0.84);

        }

        public IActionResult EuroYen(double importe)
        {

            double modeloVista = _conversor.Calcular(importe);
            return View(modeloVista *= 131.66);

        }

        public IActionResult EuroFranco(double importe)
        {

         
            double modeloVista = _conversor.Calcular(importe);
            return View(modeloVista *= 1.03);

        }

    }
    public interface IConversor
    {
        double Calcular(double importe);
    }

    public class ConversorEuroDolar : IConversor
    {
        public double Calcular(double importe)
        {
            return importe;
        }
    }

    public class ConversorEuroLibra : IConversor
    {
        public double Calcular(double importe)
        {
            return importe;
        }
    }

    public class ConversorEuroYen : IConversor
    {
        public double Calcular(double importe)
        {
            return importe;
        }
    }

    public class ConversorEuroFranco : IConversor
    {
        public double Calcular(double importe)
        {
            return importe;
        }
    }

}

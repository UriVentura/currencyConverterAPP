using AutoMapper;
using CCTransferApi.DbContexts;
using CCTransferApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CCTransferApi.Controllers
{
    [Route("api/moneda")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        //Instanciar contexto y mapper
        private readonly CCTransferDbContext _monedaContext;
        private readonly IMapper _mapper;


        //Constructor 
        public MonedaController(CCTransferDbContext cCTransferDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _monedaContext = cCTransferDbContext;
        }

        //Metodo Get para obtener monedas
        [HttpGet]
        public IActionResult GetMoneda()
        {
            //Recuperar lista de monedas
            return Ok(_mapper.Map<IEnumerable<MonedaDto>>(_monedaContext.Monedas.ToList()));
        }

        //Metodo Get con ID para obtener los datos desde la ID
        [HttpGet("{id}")]
        public IActionResult GetMonedaById(int id)
        {
            //Petición y búsqueda para obtener la variable MONEDA con un ID indicado 
            var moneda = _monedaContext.Monedas.FirstOrDefault(moneda => moneda.Id == id);
            //Si es null retorna que no lo ha encontrado
            if (moneda == null)
                return NotFound();
            //Si la encuentra devuelve Ok con la Moneda determinada
            return Ok(_mapper.Map<MonedaDto>(moneda));
        }

        //Metodo Create que crea moneda con sus propiedades
        [HttpPost]
        public ActionResult<MonedaDto> CrearMoneda(MonedaDto moneda)
        {

            var monedaEntity = _mapper.Map<Moneda>(moneda);

            _monedaContext.Add(monedaEntity);

            _monedaContext.SaveChanges();

            return Ok(monedaEntity);

        }

        //Metodo Update para actualizar la moneda
        [HttpPut("{id}")]
        public IActionResult UpdatearMoneda(int id, MonedaDto monedaUpdate)
        {
            var moneda = _monedaContext.Monedas.FirstOrDefault(moneda => moneda.Id == id);
            if (moneda == null)
                return NotFound();
            moneda.NomMoneda = monedaUpdate.NomMoneda;
            moneda.CodMoneda = monedaUpdate.CodMoneda;
            _monedaContext.Update(moneda);
            _monedaContext.SaveChanges();
            return NoContent();
        }

        //Metodo de borrar, coges la moneda y guardamos los cambios
        [HttpDelete("{id}")]
        public IActionResult DeleteMonedaById(int id, MonedaDto monedaDelete)
        {

            var moneda = _monedaContext.Monedas.FirstOrDefault(moneda => moneda.Id == id);
            if (moneda == null)
            {
                return NotFound();
            }
            _monedaContext.Monedas.Remove(moneda);
            _monedaContext.SaveChanges();
            return NoContent();
        }
    }
}

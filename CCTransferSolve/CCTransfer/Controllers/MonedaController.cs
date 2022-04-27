using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CCTransfer.Models;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;

namespace CCTransfer.Controllers
{
    [Route("api/coin")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        // 1. Instanciar el CONTEXTO
        private readonly CCTransferDbContext _cCTransferDbContext;
        // 2. Instanciar el MAPPER
        private readonly IMapper _mapper;


        // 3. Añadir CONSTRUCTOR con unos 
        public CoinController(CCTransferDbContext cCTransferDbContext, IMapper mapper)
        {
            _mapper = mapper;
            _cCTransferDbContext = cCTransferDbContext;
        }

        // 4. MÉTODO GETCOIN: permite obtener todas las monedas
        // GET
        [HttpGet]
        public IActionResult GetCoin()
        {
            // 5. Recuperar la lista de todas las monedas, si la respuesta es correcta (OK = 200)
            //_mapper.Map<IEnumerable<CoinDto>>(CCTransferDbContext.Coins);
            return Ok(_mapper.Map<IEnumerable<CoinDto>>(_cCTransferDbContext.Coins.ToList()));
        }

        // 6. MÉTODO GETCOINBYID: permite obtener una sóla moneda por su ID (pasado por parámetro)
        //api/coin/1
        [HttpGet("{id}")]
        public IActionResult GetCoinById(int id)
        {
            // 7. Petición y búsqueda para obtener la variable MONEDA con un ID indicado 
            var moneda = _cCTransferDbContext.Coins.FirstOrDefault(moneda => moneda.Id == id);
            // 8. Si el resultado de la búsqueda de la variable MONEDA, es nulo (NULL)
            if (moneda == null)
            {
                // Retornar que no se ha encontrado la variable MONEDA con el ID indicado
                return NotFound();
            }
            // 9. Si el resultado es correcto (OK = 200), retorna la variable MONEDA con el ID indicado.
            //  Mostrando la variable con sus propiedades
            return Ok(_mapper.Map<CoinDto>(moneda));
        }

        // MÉTODO CREATECOIN: permite crear una nueva moneda con sus propiedades correspondientes (ID, NAMECOIN, CODECOIN)
        // POST
        [HttpPost]
        public ActionResult<CoinDto> CreateCoin(CoinDto coin)
        {
            // 10. Crear una variable COINENTITY mapeada
            var coinEntity = _mapper.Map<Coin>(coin);
            // 11. Añadir el variable COINENTITY a la base de datos (_cCTransferDbContext)
            _cCTransferDbContext.Add(coinEntity);
            // 12. Guardar la variable COINENTITY en la base de datos (_cCTransferDbContext) (*Guardar los cambios producidos en la base de datos.)
            _cCTransferDbContext.SaveChanges();

            // 13. Retornar la variable COINENTITY, que ha sido añadida
            return Ok(coinEntity);

        }


        // DELETE
        // MÉTODO DELETECOINBYID: permite eliminar una moneda de la base de datos, según el ID indicado.
        [HttpDelete("{id}")]
        public IActionResult DeleteCoinById(int id)
        {

            // 14. Petición y búsqueda para obtener la variable MONEDA con un ID indicado 
            var moneda = _cCTransferDbContext.Coins.FirstOrDefault(moneda => moneda.Id == id);
            // 15. Si el resultado de la búsqueda de la variable MONEDA, es nulo (NULL)
            if (moneda == null)
            {
                // 16. Retornar que no se ha encontrado la variable MONEDA con el ID indicado
                return NotFound();
            }
            // 17. Crear una variable COINDELETE mapeada
            var coinDelete = _mapper.Map<Coin>(moneda);
            // 18. Eliminar la variable COINDELETE, según el ID pasado por parámetrp
            _cCTransferDbContext.Remove(coinDelete);
            // 19. Guardar la variable COINENTITY en la base de datos(_cCTransferDbContext) (*Guardar los cambios producidos en la base de datos.)
            _cCTransferDbContext.SaveChanges();

            // 20. Retornar la variable COINDELETE, que ha sido eliminada
            return Ok(coinDelete);

        }

    }
}

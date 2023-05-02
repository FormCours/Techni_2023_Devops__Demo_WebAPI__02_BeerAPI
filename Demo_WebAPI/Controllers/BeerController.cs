using Demo_WebAPI.BLL.Interfaces;
using Demo_WebAPI.DTO;
using Demo_WebAPI.DTO.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        // Variable pour utiliser le BeerService de la BLL
        private readonly IBeerService _BeerService;


        // Injection du service via le contructeur
        public BeerController(IBeerService beerService)
        {
            _BeerService = beerService;
        }


        // Route: (GET) /api/Beer/42
        [HttpGet("{id:int}")]
        public IActionResult GetOne(int id /* Parametre "id" de la route */)
        {
            BeerDTO? beer = _BeerService.GetById(id)?.ToDTO();

            if(beer is null)
            {
                return NotFound();
            }

            return Ok(beer);
        }

        // Route: (GET) /api/Beer/
        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<BeerDTO> beers = _BeerService.GetAll().Select(b => b.ToDTO());
            return Ok(beers);
        }

        // Route: (POST) /api/beer/
        [HttpPost]
        public IActionResult Add(BeerDataDTO dataDTO)
        {
            int? beerId = _BeerService.Add(dataDTO.ToModel());

            if(beerId is null)
            {
                return BadRequest("Erreur lors de l'ajout");
            }

            BeerDTO? beer = _BeerService.GetById((int)beerId)?.ToDTO();

            return CreatedAtAction(nameof(GetOne), new { Id = beerId }, beer);
        }

        // Route: (PUT) /api/beer/42
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, BeerDataDTO dataDTO) 
        {
            return StatusCode(StatusCodes.Status501NotImplemented);
        }

        // Route: (DELETE) /api/beer/42
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = _BeerService.Delete(id);

            if(!isDeleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

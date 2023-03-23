using DesafioPokemon.Dto;
using DesafioPokemon.Models;
using DesafioPokemon.Repositories.Interfaces;
using DesafioPokemon.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPokemon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IMasterPokemonRepository _masterPokemonRepository;
        private readonly IPokemonCapturedRepository _pokemonCapturedRepository;

        public PokemonController(
        IMasterPokemonRepository masterPokemonRepository,
        IPokemonCapturedRepository pokemonCapturedRepository)
        {
            _masterPokemonRepository = masterPokemonRepository;
            _pokemonCapturedRepository = pokemonCapturedRepository;
        }

        // GET
        [HttpGet("GetPokemonDetails/{nomePokemon}")]
        public async Task<object> GetPokemonDetails(string nomePokemon)
        {

            var result = await PokemonsServices.GetPokemonDetails(nomePokemon.Trim());

            if (result != null)
                return result;

            return NotFound();
        }

        // GET
        [HttpGet("GetPokemonsAleatorios")]
        public async Task<object> GetPokemonsAleatorios()
        {

            var result = await PokemonsServices.GetPokemonsAleatorios();

            if (result != null)
                return result;

            return NotFound();
        }

        // POST
        [HttpPost("CreateMasterPokemon")]
        public async Task<object> CreateMasterPokemon([FromBody] MasterPokemonDto masterPokemonDto)
        {
            using (var service = new MasterPokemonServices(_masterPokemonRepository))
            {
                var result = service.AddNewMasterPokemon(masterPokemonDto).Result;
                if (result != null)
                    return result;
            }


            return NotFound();
        }

        // POST
        [HttpPost("CapiturePokemon")]
        public object CapiturePokemon([FromQuery] string nomePokemon, int masterPokemonId)
        {
            PokemonCaptured pokemonCaptured = new PokemonCaptured();

            using (var service = new PokemonCapturedServices(_pokemonCapturedRepository))
            {
                pokemonCaptured = service.CapturePokemon(nomePokemon.ToLower(), masterPokemonId ).Result;
            }

            if (pokemonCaptured != null)
                return new {message = "Novo pokemon capiturado com sucesso!", pokemon =  pokemonCaptured };

            return NotFound();
        }

        // GET
        [HttpGet("GetAllPokemonsByMasterId")]
        public IActionResult GetPokemonsAleatorios(int masterPokemonId)
        {
            using (var service = new PokemonCapturedServices(_pokemonCapturedRepository))
            {
                var result = service.GetAllByMasterPokemon(masterPokemonId).Result;
                
                if (result != null)
                    return Ok(result);
            }

            return NotFound();
        }

    }
}

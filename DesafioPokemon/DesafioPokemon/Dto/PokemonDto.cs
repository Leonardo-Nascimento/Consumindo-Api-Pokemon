using DesafioPokemon.Models;

namespace DesafioPokemon.Dto
{
    public class PokemonDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public List<EvolutionDto> Evolutions { get; set; }
    }
}

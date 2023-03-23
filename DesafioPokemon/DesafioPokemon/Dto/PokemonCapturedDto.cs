using DesafioPokemon.Models;

namespace DesafioPokemon.Dto
{
    public class PokemonCapturedDto
    {
        public int? Id { get; set; }
        public int? PokemonId { get; set; }
        public PokemonDto? Pokemon { get; set; }

        public int? MasterPokemonId { get; set; }
        public MasterPokemonDto? MasterPokemon { get; set; }

    }
}

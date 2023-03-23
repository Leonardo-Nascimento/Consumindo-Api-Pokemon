using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPokemon.Models
{
    public class PokemonCaptured
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }

        public int MasterPokemonId { get; set; }
        public MasterPokemon MasterPokemon { get; set; }

    }
}

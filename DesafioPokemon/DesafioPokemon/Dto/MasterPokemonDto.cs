using DesafioPokemon.Models;

namespace DesafioPokemon.Dto
{
    public class MasterPokemonDto
    {
        public MasterPokemonDto()
        {
            PokemonCaptureds = new List<PokemonCapturedDto>();
        }

        public int? Id { get; set; }
        public int Idade { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public List<PokemonCapturedDto>? PokemonCaptureds { get; set; }
    }
}

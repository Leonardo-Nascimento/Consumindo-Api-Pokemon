using DesafioPokemon.Models;

namespace DesafioPokemon.Repositories.Interfaces
{
    public interface IPokemonCapturedRepository
    {
        PokemonCaptured Add(PokemonCaptured pokemonCaptured);
        IEnumerable<PokemonCaptured> GetAll();
        PokemonCaptured GetbyId(int id);        
        PokemonCaptured GetByPokemonId(int id);
        void Delete(PokemonCaptured pokemonCaptured);
        PokemonCaptured Update(PokemonCaptured pokemonCaptured);
    }
}

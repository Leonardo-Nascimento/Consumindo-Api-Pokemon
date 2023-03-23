using DesafioPokemon.Models;

namespace DesafioPokemon.Repositories.Interfaces
{
    public interface IPokemonRepository
    {
        void Add(Pokemon pokemon);
        IEnumerable<Pokemon> GetAll();
        Pokemon GetbyId(int id);
        Pokemon GetbyName(string id);
        void Delete(Pokemon pokemon);
        Pokemon Update(Pokemon pokemon);
    }
}

using DesafioPokemon.Models;

namespace DesafioPokemon.Repositories.Interfaces
{
    public interface IMasterPokemonRepository
    {
        MasterPokemon Add(MasterPokemon masterPokemon);
        IEnumerable<MasterPokemon> GetAll();
        MasterPokemon GetbyId(int id);
        MasterPokemon GetbyName(string id);
        void Delete(MasterPokemon masterPokemon);
        MasterPokemon Update(MasterPokemon masterPokemon);
    }
}

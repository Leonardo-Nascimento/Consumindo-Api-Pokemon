using DesafioPokemon.Models;

namespace DesafioPokemon.Repositories.Interfaces
{
    public interface IEvolutionRepository
    {
        void Add(Evolution evolution);        
        //Evolution GetbyId(int id);
        //Evolution GetbyName(string id);
        void Delete(Evolution evolution);
        //Evolution Update(Evolution evolution);
    }
}

using DesafioPokemon.Infra.Context;
using DesafioPokemon.Infra.Uow;
using DesafioPokemon.Models;
using DesafioPokemon.Repositories.Interfaces;

namespace DesafioPokemon.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUnitOfWork _unitOfWork;

        public PokemonRepository(DataContext dataContext, IUnitOfWork unitOfWork)
        {
            _dataContext = dataContext;
            _unitOfWork = unitOfWork;
        }

        public void Add(Pokemon pokemon)
        {
            _dataContext.Add(pokemon);
            _unitOfWork.Commit();
        }

        public void Delete(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pokemon> GetAll()
        {
            throw new NotImplementedException();
        }

        public Pokemon GetbyId(int id)
        {
            return _dataContext.Set<Pokemon>().Find(id);
        }

        public Pokemon GetbyName(string id)
        {
            throw new NotImplementedException();
        }

        public Pokemon Update(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}

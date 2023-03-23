using DesafioPokemon.Infra.Context;
using DesafioPokemon.Infra.Uow;
using DesafioPokemon.Models;
using DesafioPokemon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioPokemon.Repositories
{
    public class PokemonCapturedRepository : IPokemonCapturedRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUnitOfWork _unitOfWork;


        public PokemonCapturedRepository(DataContext dataContext, IUnitOfWork unitOfWork)
        {
            _dataContext = dataContext;
            _unitOfWork = unitOfWork;
        }

        public PokemonCaptured Add(PokemonCaptured masterPokemon)
        {
            _dataContext.Add(masterPokemon);
            _unitOfWork.Commit();

            return masterPokemon;
        }

        public void Delete(PokemonCaptured masterPokemon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PokemonCaptured> GetAll()
        {
           return  _dataContext.Set<PokemonCaptured>().AsQueryable().AsNoTracking();
        }

        public PokemonCaptured GetbyId(int id)
        {
            return _dataContext.Set<PokemonCaptured>().Find(id);
            ;
        }

        public PokemonCaptured GetbyName(string id)
        {
            throw new NotImplementedException();
        }

        public PokemonCaptured GetByPokemonId(int id)
        {
            return _dataContext.Set<PokemonCaptured>().FirstOrDefault(x => x.PokemonId == id);
        }

        public PokemonCaptured Update(PokemonCaptured masterPokemon)
        {
            throw new NotImplementedException();
        }
    }
}

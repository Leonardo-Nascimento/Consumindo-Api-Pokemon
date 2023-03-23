using DesafioPokemon.Infra.Context;
using DesafioPokemon.Infra.Uow;
using DesafioPokemon.Models;
using DesafioPokemon.Repositories.Interfaces;

namespace DesafioPokemon.Repositories
{
    public class MasterPokemonRepository : IMasterPokemonRepository
    {
        private readonly DataContext _dataContext;
        private readonly IUnitOfWork _unitOfWork;


        public MasterPokemonRepository(DataContext dataContext, IUnitOfWork unitOfWork)
        {
            _dataContext = dataContext;
            _unitOfWork = unitOfWork;
        }
        public MasterPokemon Add(MasterPokemon masterPokemon)
        {
            _dataContext.Add(masterPokemon);
            _unitOfWork.Commit();

            return masterPokemon;
        }

        public void Delete(MasterPokemon masterPokemon)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterPokemon> GetAll()
        {
            throw new NotImplementedException();
        }

        public MasterPokemon GetbyId(int id)
        {
            throw new NotImplementedException();
        }

        public MasterPokemon GetbyName(string id)
        {
            throw new NotImplementedException();
        }

        public MasterPokemon Update(MasterPokemon masterPokemon)
        {
            throw new NotImplementedException();
        }
    }
}

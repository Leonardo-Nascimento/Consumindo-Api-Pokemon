using DesafioPokemon.Dto;
using DesafioPokemon.Infra.Context;
using DesafioPokemon.Infra.Uow;
using DesafioPokemon.Models;
using DesafioPokemon.Repositories;
using DesafioPokemon.Repositories.Interfaces;

namespace DesafioPokemon.Service
{
    public class MasterPokemonServices : IDisposable
    {
        private readonly IMasterPokemonRepository _masterPokemonRepository;


        public MasterPokemonServices(IMasterPokemonRepository masterPokemonRepository)
        {
            _masterPokemonRepository = masterPokemonRepository;
        }

        public async Task<MasterPokemon> AddNewMasterPokemon(MasterPokemonDto masterPokemon)
        {
            MasterPokemon obj = new MasterPokemon();
            obj.Idade = masterPokemon.Idade;
            obj.Name = masterPokemon.Name;
            obj.CPF = masterPokemon.CPF;

            return _masterPokemonRepository.Add(obj);
        }




        #region Dispose
        bool _disposed = false;
        public void Dispose()
        {
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.

            _disposed = true;
        }

        #endregion
    }
}

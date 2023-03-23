using DesafioPokemon.Models;
using DesafioPokemon.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioPokemon.Service
{
    public class PokemonCapturedServices : IDisposable
    {
        private readonly IPokemonCapturedRepository _pokemonCapturedRepository;
        


        public PokemonCapturedServices(
            IPokemonCapturedRepository pokemonCapturedRepository
            )
        {
            _pokemonCapturedRepository = pokemonCapturedRepository;
            
        }

        public async Task<PokemonCaptured> CapturePokemon(string name, int masterPokemonId)
        {
            var pokemonCapture = new PokemonCaptured();
            pokemonCapture.Pokemon = await PokemonsServices.GetPokemonDetails(name);
            pokemonCapture.MasterPokemonId = masterPokemonId;

            if (pokemonCapture.Pokemon == null)            
                return null;

            var pokemonCapitureExiste = _pokemonCapturedRepository.GetAll()                                                                  
                                                                  .AsQueryable()                                                                  
                                                                  .Include(x => x.Pokemon)                                                                  
                                                                  .FirstOrDefault(x => x.PokemonId == pokemonCapture.Pokemon.Id);
                                                                  
            
            if (pokemonCapitureExiste != null)
                return pokemonCapitureExiste;
            
            return _pokemonCapturedRepository.Add(pokemonCapture);
        }

        public async Task<IEnumerable<PokemonCaptured>> GetAllByMasterPokemon(int masterPokemonId)
        {
            var list = _pokemonCapturedRepository.GetAll()
                                                .AsQueryable()
                                                .Include(x => x.Pokemon)
                                                .Where(x => x.MasterPokemonId == masterPokemonId)
                                                .ToList();                                
                
            return list;
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

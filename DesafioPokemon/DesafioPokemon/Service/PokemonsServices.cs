using DesafioPokemon.Models;
using System.Xml;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Reflection;
using DesafioPokemon.Dto;
using System.Xml.Linq;
using DesafioPokemon.Repositories.Interfaces;
using DesafioPokemon.Repositories;

namespace DesafioPokemon.Service
{
    public class PokemonsServices : IDisposable
    {
        const string URLGetPokemon = "https://pokeapi.co/api/v2/pokemon/";
        const string URLGetSpecies = "https://pokeapi.co/api/v2/pokemon-species/";

        private readonly IPokemonRepository _pokemonRepository;
               

        static object RequestPokeapi(string? name = null, string? url = null)
        {
            using (var cliente = new HttpClient())
            {
                if (url != null)
                {
                    string resultado = cliente.GetStringAsync(url).Result;
                    dynamic obj = JsonConvert.DeserializeObject(resultado);

                    return obj;
                }
                else
                {
                    string resultado = cliente.GetStringAsync(url + name).Result;
                    dynamic obj = JsonConvert.DeserializeObject(resultado);

                    return obj;
                }
            }
        }

        public static async Task<Pokemon> GetPokemonDetails(string name)
        {
            Pokemon pokemon = null;
            string url = string.Empty;
            string urlSpecies = string.Empty;
            string urlImage = string.Empty;

            try
            {
                using (var cliente = new HttpClient())
                {
                    url = getUrlByName(name);

                    if (!string.IsNullOrEmpty(url))
                    {
                        dynamic obj = RequestPokeapi(url);

                        if (obj != null)
                        {
                            urlImage = (string)obj.sprites.front_default;
                            urlSpecies = (string)obj.species.url;

                            pokemon = new Pokemon((int)obj.id, (string)obj.name);
                            pokemon.ImageBase64 = GetImageBase64Pokemon(urlImage);
                            pokemon.Evolutions = GetEvolutions(urlSpecies, pokemon.Name);

                            return pokemon;
                        }
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw new Exception($"Erro ao pegar dados do pokemon {name}! Favor verifique o nome do pokemon e tente novamente!");
            }
        }

        static string GetImageBase64Pokemon(string urlImage)
        {
            using (var cliente = new HttpClient())
            {
                string resultado = cliente.GetStringAsync(urlImage).Result;

                return resultado;
            }
        }

        static List<Evolution> GetEvolutions(string urlSpecies, string name)
        {
            var listEvolutions = new List<Evolution>();
            string nameFirstEvolution = string.Empty;
            string urlImage = string.Empty;

            try
            {
                using (var cliente = new HttpClient())
                {
                    dynamic obj = RequestPokeapi(null, urlSpecies);

                    string urlEvolutions = (string)obj.evolution_chain.url;

                    var resultado = cliente.GetStringAsync(urlEvolutions).Result;
                    obj = JsonConvert.DeserializeObject(resultado);

                    var index = (Newtonsoft.Json.Linq.JArray)obj.chain.evolves_to;

                    if (index.Any())
                    {
                        nameFirstEvolution = (string)obj.chain.evolves_to[0].species.name;
                    }
                    else return null;


                    var urlPokemon = getUrlByName(nameFirstEvolution);

                    if (nameFirstEvolution != name && !string.IsNullOrEmpty(urlPokemon))
                    {
                        dynamic objEvolutionResult = RequestPokeapi(urlPokemon);

                        urlImage = (string)objEvolutionResult.sprites.front_default;

                        var evolution = new Evolution(
                            (int)objEvolutionResult.id,
                            (string)objEvolutionResult.name,
                            GetImageBase64Pokemon(urlImage)
                        );

                        listEvolutions.Add(evolution);
                    }

                    var listEvolutionsResult = obj.chain.evolves_to[0].evolves_to;

                    foreach (var item in listEvolutionsResult)
                    {
                        string NameSecondEvolution = (string)item.species.name;
                        urlPokemon = getUrlByName(NameSecondEvolution);

                        if (NameSecondEvolution != name && !string.IsNullOrEmpty(urlPokemon))
                        {
                            obj = RequestPokeapi(urlPokemon);
                            urlImage = (string)obj.sprites.front_default;

                            var evolution = new Evolution(
                            (int)obj.id,
                            (string)obj.name,
                            GetImageBase64Pokemon(urlImage)
                            );

                            listEvolutions.Add(evolution);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                
            }

            return listEvolutions;
        }


        public static async Task<List<Pokemon>> GetPokemonsAleatorios()
        {
            Random randNum = new Random();
            var listNomes = new List<string>();
            var listPokemons = new List<Pokemon>();

            try
            {
                using (var reader = new StreamReader(@"Pokemons.json"))
                {
                    var json = await reader.ReadToEndAsync();
                    dynamic listNomesJson = JsonConvert.DeserializeObject(json);

                    foreach (var item in listNomesJson)
                        listNomes.Add((string)item.name);
                }

                while (listPokemons.Count < 10)
                {
                    var nomePokemonSorteado = listNomes[randNum.Next(0, listNomes.Count())];
                    var pokemon = GetPokemonDetails(nomePokemonSorteado).Result;

                    if (pokemon != null)
                        listPokemons.Add(pokemon);
                }

                return listPokemons;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao tentar acessar arquivo json: " + ex.Message);
            }
        }

        static string getUrlByName(string name)
        {
            string url = string.Empty;
            List<JsonPokemonsDto> list = new List<JsonPokemonsDto>();

            using (var reader = new StreamReader(@"Pokemons.json"))
            {
                var json = reader.ReadToEndAsync().Result;
                list = JsonConvert.DeserializeObject<List<JsonPokemonsDto>>(json);

                var obj = list.FirstOrDefault(x => x.Name == name);

                if (obj != null)
                    url = obj.Url;
            }

            return url;
        }

        //public void SavePokemon(Pokemon pokemon)
        //{
        //    var pokemonRepository = new PokemonRepository();
        //    var obj = _pokemonRepository.GetbyId(pokemon.Id);

        //    if(obj == null)
        //    _pokemonRepository.Add(pokemon);
        //}


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

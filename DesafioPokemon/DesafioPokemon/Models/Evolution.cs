using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioPokemon.Models
{
    public class Evolution
    {
        public Evolution(int id, string name, string base64)
        {
            Id = id;
            Name = name;
            Base64 = base64;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Base64 { get; set; }

        public int PokemonId { get; set; }
        public Pokemon Pokemon { get; set; }
    }
}

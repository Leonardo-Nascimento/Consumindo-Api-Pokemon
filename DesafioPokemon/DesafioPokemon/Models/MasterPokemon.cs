namespace DesafioPokemon.Models
{
    public class MasterPokemon
    {
        public MasterPokemon()
        {
            PokemonCaptureds = new List<PokemonCaptured>();
        }

        public MasterPokemon(int idade, string name, string cPF)
        {
            Idade = idade;
            Name = name;
            CPF = cPF;
        }

        public int Id { get; set; }
        public int Idade { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public List<PokemonCaptured>  PokemonCaptureds { get; set;}

    }
}

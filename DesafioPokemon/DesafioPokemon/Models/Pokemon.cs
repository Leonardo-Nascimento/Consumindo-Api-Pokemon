namespace DesafioPokemon.Models
{
    public class Pokemon
    {
        public Pokemon() 
        {
            Evolutions = new List<Evolution>();
        }

        public Pokemon(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageBase64 { get; set; }
        public List<Evolution> Evolutions { get; set; }
    }
}

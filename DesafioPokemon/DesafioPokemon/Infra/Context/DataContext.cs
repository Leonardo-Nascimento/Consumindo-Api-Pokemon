using DesafioPokemon.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DesafioPokemon.Infra.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PokemonCaptured>()
            .HasOne<MasterPokemon>(a => a.MasterPokemon)
            .WithMany(pc => pc.PokemonCaptureds)
            .HasForeignKey(pc => pc.MasterPokemonId);

            modelBuilder.Entity<Evolution>()
            .HasOne<Pokemon>(e => e.Pokemon)
            .WithMany(p => p.Evolutions)
            .HasForeignKey(e => e.PokemonId);
        }

        public DbSet<Evolution> Evolution { get; set; }
        public DbSet<MasterPokemon> MasterPokemon { get; set; }
        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<PokemonCaptured> PokemonCaptureds { get; set; }
    }
}


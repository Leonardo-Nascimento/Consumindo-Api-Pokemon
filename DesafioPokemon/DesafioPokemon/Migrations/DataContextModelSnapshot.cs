﻿// <auto-generated />
using DesafioPokemon.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioPokemon.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("DesafioPokemon.Models.Evolution", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Base64")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Evolution");
                });

            modelBuilder.Entity("DesafioPokemon.Models.MasterPokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Idade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("MasterPokemon");
                });

            modelBuilder.Entity("DesafioPokemon.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageBase64")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("DesafioPokemon.Models.PokemonCaptured", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("MasterPokemonId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PokemonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MasterPokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("PokemonCaptureds");
                });

            modelBuilder.Entity("DesafioPokemon.Models.Evolution", b =>
                {
                    b.HasOne("DesafioPokemon.Models.Pokemon", "Pokemon")
                        .WithMany("Evolutions")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("DesafioPokemon.Models.PokemonCaptured", b =>
                {
                    b.HasOne("DesafioPokemon.Models.MasterPokemon", "MasterPokemon")
                        .WithMany("PokemonCaptureds")
                        .HasForeignKey("MasterPokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DesafioPokemon.Models.Pokemon", "Pokemon")
                        .WithMany()
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MasterPokemon");

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("DesafioPokemon.Models.MasterPokemon", b =>
                {
                    b.Navigation("PokemonCaptureds");
                });

            modelBuilder.Entity("DesafioPokemon.Models.Pokemon", b =>
                {
                    b.Navigation("Evolutions");
                });
#pragma warning restore 612, 618
        }
    }
}

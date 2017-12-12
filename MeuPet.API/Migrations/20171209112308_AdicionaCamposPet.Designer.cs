﻿// <auto-generated />
using MeuPet.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MeuPet.API.Migrations
{
    [DbContext(typeof(MeuPetContext))]
    [Migration("20171209112308_AdicionaCamposPet")]
    partial class AdicionaCamposPet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeuPet.API.Models.Agenda", b =>
                {
                    b.Property<int>("AgendaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<string>("Descricao");

                    b.Property<int?>("PetId");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("AgendaId");

                    b.HasIndex("PetId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("MeuPet.API.Models.Doacao", b =>
                {
                    b.Property<int>("DoacaoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contato");

                    b.Property<string>("Descricao");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("DoacaoId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Doacao");
                });

            modelBuilder.Entity("MeuPet.API.Models.Pet", b =>
                {
                    b.Property<int>("PetId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ImageUrl");

                    b.Property<DateTime>("Nascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("Peso");

                    b.Property<string>("Raca");

                    b.Property<int?>("UsuarioId");

                    b.HasKey("PetId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Pet");
                });

            modelBuilder.Entity("MeuPet.API.Models.Usuario", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.Property<string>("Senha");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("MeuPet.API.Models.Agenda", b =>
                {
                    b.HasOne("MeuPet.API.Models.Pet", "Pet")
                        .WithMany("Agendas")
                        .HasForeignKey("PetId");

                    b.HasOne("MeuPet.API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("MeuPet.API.Models.Doacao", b =>
                {
                    b.HasOne("MeuPet.API.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("MeuPet.API.Models.Pet", b =>
                {
                    b.HasOne("MeuPet.API.Models.Usuario", "Usuario")
                        .WithMany("Pets")
                        .HasForeignKey("UsuarioId");
                });
#pragma warning restore 612, 618
        }
    }
}
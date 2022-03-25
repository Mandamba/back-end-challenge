﻿// <auto-generated />
using BookStoreCrudWebApi.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookStoreCrudWebApi.Migrations
{
    [DbContext(typeof(BookStoreContext))]
    [Migration("20220310235632_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.Autor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("newId()")
                        .HasColumnName("id");

                    b.Property<string>("NomeAutor")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("nome_autor");

                    b.HasKey("Id");

                    b.ToTable("tb_autores");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.Genero", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("newId()")
                        .HasColumnName("id");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("genero");

                    b.HasKey("Id");

                    b.ToTable("tb_generos");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.GeneroLivro", b =>
                {
                    b.Property<string>("livroId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("livro_id");

                    b.Property<string>("generoId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("genero_id");

                    b.HasKey("livroId", "generoId");

                    b.HasIndex("generoId");

                    b.ToTable("tb_genero_livros");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.Livro", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("newId()")
                        .HasColumnName("id");

                    b.Property<long>("QuantidadeCopias")
                        .HasColumnType("bigint")
                        .HasColumnName("quantidade_copias");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasColumnName("titulo");

                    b.HasKey("Id");

                    b.ToTable("tb_livros");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.LivroAutores", b =>
                {
                    b.Property<string>("livroId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("livro_id");

                    b.Property<string>("autorId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("autor_id");

                    b.HasKey("livroId", "autorId");

                    b.HasIndex("autorId");

                    b.ToTable("tb_livros_autores");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.GeneroLivro", b =>
                {
                    b.HasOne("BookStoreCrudWebApi.Models.Entidades.Genero", "Genero")
                        .WithMany("GeneroLivro")
                        .HasForeignKey("generoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreCrudWebApi.Models.Entidades.Livro", "Livro")
                        .WithMany("GeneroLivro")
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.LivroAutores", b =>
                {
                    b.HasOne("BookStoreCrudWebApi.Models.Entidades.Autor", "Autor")
                        .WithMany("LivroAutores")
                        .HasForeignKey("autorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookStoreCrudWebApi.Models.Entidades.Livro", "Livro")
                        .WithMany("LivroAutores")
                        .HasForeignKey("livroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");

                    b.Navigation("Livro");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.Autor", b =>
                {
                    b.Navigation("LivroAutores");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.Genero", b =>
                {
                    b.Navigation("GeneroLivro");
                });

            modelBuilder.Entity("BookStoreCrudWebApi.Models.Entidades.Livro", b =>
                {
                    b.Navigation("GeneroLivro");

                    b.Navigation("LivroAutores");
                });
#pragma warning restore 612, 618
        }
    }
}
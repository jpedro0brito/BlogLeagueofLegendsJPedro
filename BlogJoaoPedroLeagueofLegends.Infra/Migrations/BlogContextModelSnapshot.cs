﻿// <auto-generated />
using System;
using BlogJoaoPedroLeagueofLegends.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogJoaoPedroLeagueofLegends.Infra.Migrations
{
    [DbContext(typeof(BlogContext))]
    partial class BlogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogJoaoPedroLeagueofLegends.DoMain.Entities.Categoria", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("descricao")
                        .HasMaxLength(500);

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BlogJoaoPedroLeagueofLegends.DoMain.Entities.Posts", b =>
                {
                    b.Property<int>("PostId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoriaId");

                    b.Property<string>("Post")
                        .HasMaxLength(500);

                    b.Property<string>("SubTitulo")
                        .HasMaxLength(100);

                    b.Property<string>("Titulo")
                        .HasMaxLength(100);

                    b.HasKey("PostId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BlogJoaoPedroLeagueofLegends.DoMain.Entities.Posts", b =>
                {
                    b.HasOne("BlogJoaoPedroLeagueofLegends.DoMain.Entities.Categoria", "Categoria")
                        .WithMany("Posts")
                        .HasForeignKey("CategoriaId");
                });
#pragma warning restore 612, 618
        }
    }
}

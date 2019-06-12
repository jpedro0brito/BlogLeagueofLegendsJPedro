using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using BlogJoaoPedroLeagueofLegends.Infra.EntityConfing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.Infra.Context
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options):base(options){ }

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new PostsConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaConfiguration());
        }
    }
}

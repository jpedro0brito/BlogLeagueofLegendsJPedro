using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.Infra.EntityConfing
{
    public class PostsConfiguration : IEntityTypeConfiguration<Posts>
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.HasKey(p => p.PostId);
            builder.Property(p => p.Post).HasMaxLength(500);
            builder.Property(p => p.Titulo).HasMaxLength(100);
            builder.Property(p => p.SubTitulo).HasMaxLength(100);
        }
    }
}

using BlogJoaoPedroLeagueofLegends.DoMain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogJoaoPedroLeagueofLegends.Infra.EntityConfing
{
    class CategoriaConfiguration: IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.descricao).HasMaxLength(500);
        }
    }
}

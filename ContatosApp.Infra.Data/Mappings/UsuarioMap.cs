using ApiContatos.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContatos.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para contatos
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(f => f.IdUsuario);
            builder.Property(f => f.Email).HasMaxLength(150);
            builder.HasIndex(f => f.Email).IsUnique();
        }
    }
}

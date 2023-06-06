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
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(f => f.IdContato);
        }
    }
}

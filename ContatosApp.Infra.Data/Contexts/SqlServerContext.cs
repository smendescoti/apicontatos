using ApiContatos.Infra.Data.Entities;
using ApiContatos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContatos.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para acesso ao banco de dados com o EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //construtor para inicializar a conexão com o banco de dados
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        //adicionar cada classe de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContatoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        //criar uma propriedade do tipo DbSet (CRUD) para cada classe de entidade
        public DbSet<Contato> contatos { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}

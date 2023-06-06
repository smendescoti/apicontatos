using ApiContatos.Infra.Data.Contexts;
using ApiContatos.Infra.Data.Entities;
using ApiContatos.Infra.Data.Interfaces;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContatos.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para injeção de dependência (inicialização)
        public UsuarioRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Usuario Get(string email)
        {
            return _sqlServerContext.Usuario.FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario Get(string email, string senha)
        {
            return _sqlServerContext.Usuario.FirstOrDefault(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}

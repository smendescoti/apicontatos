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
    public class ContatoRepository : BaseRepository<Contato>, IContatoRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para injeção de dependência (inicialização)
        public ContatoRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }
    }
}

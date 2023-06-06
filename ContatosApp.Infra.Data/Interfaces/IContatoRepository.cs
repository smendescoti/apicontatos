using ApiContatos.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContatos.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório específica para contatos
    /// </summary>
    public interface IContatoRepository : IBaseRepository<Contato>
    {
        
    }
}

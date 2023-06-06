using ApiContatos.Infra.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiContatos.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IContatoRepository _contatoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public DashboardController(IContatoRepository contatoRepository, IUsuarioRepository usuarioRepository)
        {
            _contatoRepository = contatoRepository;
            _usuarioRepository = usuarioRepository;
        }

        [ProducesResponseType(200, Type = typeof(List<DashboardModel>))]
        [HttpGet()]
        public IActionResult GetAll()
        {
            var usuario = _usuarioRepository.Get(User.Identity.Name);

            var contatos = _contatoRepository.Consultar()
                .Where(c => c.IdUsuario == usuario.IdUsuario)
                .ToList();

            var resultado = contatos.GroupBy(c => c.DataCriacao.Date.ToString("dd/MM/yyyy"))
                        .Select(g => new { Data = g.Key, Quantidade = g.Count() });

            var lista = new List<DashboardModel>();
            foreach (var item in resultado)
            {
                lista.Add(new DashboardModel
                {
                    Name = item.Data,
                    Data = item.Quantidade
                });
            }

            return StatusCode(200, lista);
        }
    }

    public class DashboardModel
    {
        public string? Name { get; set; }
        public decimal? Data { get; set; }
    }
}

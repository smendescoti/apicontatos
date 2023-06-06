using ApiContatos.Infra.Data.Entities;
using ApiContatos.Infra.Data.Interfaces;
using ApiContatos.Services.Authentication;
using ApiContatos.Services.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiContatos.Services.Controllers
{
    [Route("api/autenticar")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenCreator _tokenCreator;

        public AutenticarController(IUsuarioRepository usuarioRepository, TokenCreator tokenCreator)
        {
            _usuarioRepository = usuarioRepository;
            _tokenCreator = tokenCreator;
        }

        [HttpPost]
        public IActionResult Post(LoginPostModel model)
        {
            try
            {
                //buscando o usuário no banco de dados através do email e senha
                var usuario = _usuarioRepository.Get(model.Email, model.Senha);

                //verificar se o usuário foi encontrado
                if (usuario != null)
                {
                    //retornar resposta de sucesso com o token
                    return StatusCode(200, new
                    {
                        idUsuario = usuario.IdUsuario,
                        nome = usuario.Nome,
                        email = usuario.Email,
                        accessToken = _tokenCreator.GenerateToken(usuario.Email),
                        createdAt = DateTime.Now,
                        expiration = DateTime.Now.AddHours(24)
                    });
                }
                else
                {
                    //HTTP STATUS 401 - UNAUTHORIZED
                    return StatusCode(401, new { message = "Acesso não autorizado, email e senha inválidos." });
                }
            }
            catch (Exception e)
            {
                //HTTP STATUS 500 (INTERNAL SERVER ERROR)
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}

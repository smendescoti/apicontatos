using System.ComponentModel.DataAnnotations;

namespace ApiContatos.Services.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de cadastro de contatos
    /// </summary>
    public class ContatoPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf.")]
        public string Telefone { get; set; }
    }
}

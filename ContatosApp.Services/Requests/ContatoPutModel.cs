using System.ComponentModel.DataAnnotations;

namespace ApiContatos.Services.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de atualização de contatos
    /// </summary>
    public class ContatoPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do contato.")]
        public Guid IdContato { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf.")]
        public string Telefone { get; set; }
    }
}

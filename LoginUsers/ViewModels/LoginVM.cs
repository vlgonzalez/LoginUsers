using System.ComponentModel.DataAnnotations;

namespace LoginUsers.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email obrigatorio.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha invalida.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}

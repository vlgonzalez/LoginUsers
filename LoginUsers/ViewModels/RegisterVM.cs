using System.ComponentModel.DataAnnotations;

namespace LoginUsers.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "O nome é obrigatorio.")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }
        
        [Required(ErrorMessage = "Email invalido.")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Digite uma senha valida.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Senha invalida.")]
        [Display(Name = "Confirme a senha")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}

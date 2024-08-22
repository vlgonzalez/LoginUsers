using System.ComponentModel.DataAnnotations;

namespace LoginUsers.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email obrigatorio.")]
        [EmailAddress(ErrorMessage = "Insira um email válido.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}

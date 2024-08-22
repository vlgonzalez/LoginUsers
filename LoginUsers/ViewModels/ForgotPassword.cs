using System.ComponentModel.DataAnnotations;

namespace LoginUsers.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required(ErrorMessage = "Email obrigatorio.")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
    }
}

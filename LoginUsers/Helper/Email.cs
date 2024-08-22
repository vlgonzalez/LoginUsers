using System.Net.Mail;

namespace LoginUsers.Helper
{
    public class Email : IEmail
    {
        private readonly IConfiguration _configuration;

        public Email (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SendEmail(string email, string name, string newPassword)
        {
        try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(email);
                mail.From = new MailAddress("Email_do_remetente");
                mail.Subject = "Redefinir senha";
                string Body = $"Ola,{name}, segue nova senha {newPassword}";
                mail.Body = Body;
                mail.IsBodyHtml = true;

                //Instância smtp do servidor, neste caso o gmail.
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("Email_do_remetente", "Senha_email");// Login e senha do e-mail.
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return true;

            } 
        catch (Exception ex) 
            {
                return false;
            }
           
        }
    }
}

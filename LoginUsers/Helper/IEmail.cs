namespace LoginUsers.Helper
{
    public interface IEmail
    {
        bool SendEmail (string email, string name, string link);
    }
}

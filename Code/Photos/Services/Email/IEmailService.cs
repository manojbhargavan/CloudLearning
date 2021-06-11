namespace Photos.Services.Email
{
    //Fluent Builder
    public interface IEmailService
    {
        IEmailService AddToAddress(string value);
        IEmailService AddFromAddress(string value);
        IEmailService AddSubject(string value);
        IEmailService AddBody(string value);
        void SendMail();
    }
}
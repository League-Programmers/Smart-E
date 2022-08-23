namespace Smart_E.Models
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendConfirmationEmailTest(UserEmailOptions userEmailOptions);
    }
}
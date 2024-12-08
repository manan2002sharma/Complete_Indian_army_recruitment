namespace Indian_Army_Recruitment.Services.ServiceInterfaces
{
    public interface IEmailService
    {
        Task<bool> SendEmailAsync(string email, string subject, string message);
    }
}

using System.Threading.Tasks;

namespace Norma.Business.Intefaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}

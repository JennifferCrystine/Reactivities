using Resend;

namespace Infrastruture.Email;

public interface IEmailClient
{
    public Task SendAsync(EmailMessage message);
}

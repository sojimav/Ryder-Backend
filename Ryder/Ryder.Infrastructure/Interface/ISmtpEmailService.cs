using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryder.Infrastructure.Interface
{
    public interface ISmtpEmailService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string message);
    }
}

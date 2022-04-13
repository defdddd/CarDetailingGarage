using CDG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDG.Service.Interfaces
{
    public interface IEmailService
    {
         Task SendCratedEmailAsync(EmailModel value);
         Task SendAppointmentMadeEmailAsync(EmailModel value);
         Task SendAppointmentFinishedEmailAsync(EmailModel value);
         Task SendForgotPasswordEmailAsync(EmailModel value);
         Task<dynamic> GetTokenForForgotPasswordAsync(string email, string key);
    }
}

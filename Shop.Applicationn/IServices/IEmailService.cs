using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Applicationn.IServices
{
    public interface IEmailService
    {
        void SendEmail(string userEmail, string subject, string htmlMessage);
    }
}

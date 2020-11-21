using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Infraestructure.Interfaces
{
    public interface IMailService
    {

        Task<bool> SendMail(string subject, string content, string[] recipients);

        Task<bool> ConfirmPassword(string url, string[] recipients);

        Task<bool> ResetPassword(string url, string[] recipients);

        Task<bool> NewLogin(string[] recipients);
    }


}

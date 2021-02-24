using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Core.DTOs
{
    public class ClientDto
    {
        public decimal? Document { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public string NewsletterMail { get; set; }

        public decimal? NewsletterActive { get; set; }
    }
}

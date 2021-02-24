using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.Entities
{
    public class UserManagerResponse
    {
        public long ClientId { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }

        public string UserName { get; set; }
        public string FirstName {get; set;}
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Profile { get; set; }

    }
}
 
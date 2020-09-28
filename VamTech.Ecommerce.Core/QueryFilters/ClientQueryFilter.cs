using System;
using System.Collections.Generic;
using System.Text;

namespace VamTech.Ecommerce.Core.QueryFilters
{
    public class ClientQueryFilter
    {
        public int? UserId { get; set; }
                
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}

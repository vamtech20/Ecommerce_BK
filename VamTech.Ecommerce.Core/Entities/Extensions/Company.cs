using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VamTech.Ecommerce.Core.Entities
{

    [MetadataType(typeof(Company_Validation))]
    public partial class Company
    {
       
        public int PendingPOCount
        {
            get
            {

                return 0;
            }

        }



    }
    public class Company_Validation
    {


    }

}

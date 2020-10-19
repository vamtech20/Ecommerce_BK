using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VamTech.Ecommerce.Core.Entities
{

    [MetadataType(typeof(Offer_Validation))]
    public partial class Offer
    {
       
        public bool IsActive
        {
            get
            {
              
                return  ValidFrom <= DateTime.Today && ValidTo >= DateTime.Today ;
            }

        }


    }
    public class Offer_Validation
    {


    }

}

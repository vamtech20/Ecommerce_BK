using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace VamTech.Ecommerce.Core.Entities
{

    [MetadataType(typeof(Product_Validation))]
    public partial class Product
    {
       
        public string LongDesc
        {
            get
            {
                return Description + '-' + Brand.Description; ;
            }

        }

        public OfferDetail ActiveOffer
        {
            get
            {
             
                return this.Offers.Where(x => x.Offer.IsActive).FirstOrDefault(); 
            }

        }


    }
    public class Product_Validation
    {
        //public string Description { get; set; }

    }

}

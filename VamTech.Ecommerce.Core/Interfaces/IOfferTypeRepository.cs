using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Core.Interfaces
{

    public interface IOfferTypeRepository : IRepository<OfferType>
    {
        Task<IEnumerable<OfferType>> GetOfferTypes();
    }
}

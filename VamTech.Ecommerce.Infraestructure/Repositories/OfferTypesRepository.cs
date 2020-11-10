using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Infraestructure.Data;
using VamTech.Ecommerce.Infrastructure.Repositories;

namespace Vamtech.Ecommerce.Infrastructure.Repositories
{
    public class OfferTypeRepository : BaseRepository<OfferType>, IOfferTypeRepository
    {
        public OfferTypeRepository(VamtechEcommerceContext context) : base(context) { }

        public async Task<IEnumerable<OfferType>> GetOfferTypes()
        {
            return await _entities.ToListAsync();
        }

       
    }
}

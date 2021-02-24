using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Infraestructure.Data;
using VamTech.Ecommerce.Infraestructure.Repositories;

namespace VamTech.Ecommerce.Infraestructure.Repositories
{
    public class OfferRepository : BaseRepository<Offer>, IOfferRepository
    {
        public OfferRepository(VamTechEcommerceContext context) : base(context) { }
        public async Task<IEnumerable<Offer>> GetOffers()
        {
            return await _entities.ToListAsync();
        }

    }
}

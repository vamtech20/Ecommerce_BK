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
using VamTech.Ecommerce.Infraestructure.Repositories;

namespace VamTech.Ecommerce.Infraestructure.Repositories
{
    public class OfferTypeRepository : BaseRepository<OfferType>, IOfferTypeRepository
    {
        public OfferTypeRepository(VamTechEcommerceContext context) : base(context) { }

        public async Task<IEnumerable<OfferType>> GetOfferTypes()
        {
            return await _entities.ToListAsync();
        }

       
    }
}

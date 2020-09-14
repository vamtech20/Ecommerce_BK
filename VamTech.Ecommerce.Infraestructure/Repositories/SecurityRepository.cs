using Microsoft.EntityFrameworkCore;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Infrastructure.Data;
using System.Threading.Tasks;
using VamTech.Ecommerce.Infraestructure.Data;

namespace VamTech.Ecommerce.Infrastructure.Repositories
{
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(VamtechEcommerceContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}

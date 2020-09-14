using VamTech.Ecommerce.Core.Entities;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
using VamTech.Ecommerce.Core.Entities;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
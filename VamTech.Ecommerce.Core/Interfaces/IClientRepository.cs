using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.Entities;

namespace VamTech.Ecommerce.Core.Interfaces
{
    
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<Client>> GetClients();
    }
}

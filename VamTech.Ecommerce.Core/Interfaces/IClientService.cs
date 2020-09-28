using System.Collections.Generic;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IClientService
    {
        PagedList<Client> GetClients(ClientQueryFilter filters);
        Task<Client> GetClient(int id);

        Task InsertClient(Client client);

        Task<bool> UpdateClient(Client client);

        Task<bool> DeleteClient(int id);

        Client GetClientByEmail(string email);
               
        Task CreateClient(UserDto userDto);

        UserDto GetClient(UserDto userDto);
    }
}
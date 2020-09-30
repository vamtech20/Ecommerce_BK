using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Exceptions;
using VamTech.Ecommerce.Core.Interfaces;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
        }
        public PagedList<Client> GetClients(ClientQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var Clients = _unitOfWork.ClientRepository.GetAll();


            var pagedProducts = PagedList<Client>.Create(Clients, filters.PageNumber, filters.PageSize);
            return pagedProducts;
        }
        public async Task<Client> GetClient(int id)
        {
            return await _unitOfWork.ClientRepository.GetById(id);
        }

       
        public async Task InsertClient(Client client)
        {
            
            await _unitOfWork.ClientRepository.Add(client);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateClient(Client client)
        {
            var existingItem = await _unitOfWork.ClientRepository.GetById(client.Id);
          

            _unitOfWork.ClientRepository.Update(existingItem);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClient(int id)
        {
            await _unitOfWork.ClientRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public Client GetClientByEmail(string email)
        {
            var Clients = _unitOfWork.ClientRepository.GetAll();

            return Clients.Where(x=>  x.Email == email)
                 .FirstOrDefault();
        }

        public async Task CreateClient(ClientDto userDto)
        {
            var client = _mapper.Map<Client>(userDto);
            await InsertClient(client);
        }
        
    }
}

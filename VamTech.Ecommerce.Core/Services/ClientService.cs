using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
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
        private readonly IUriService _uriService;

        public ClientService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
        }
        public IEnumerable<ClientDto> GetClients(ClientQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var Clients = _unitOfWork.ClientRepository.GetAll();


            var pagedClients = PagedList<Client>.Create(Clients, filters.PageNumber, filters.PageSize);

            var ClientsDtos = _mapper.Map<IEnumerable<ClientDto>>(pagedClients);

            metadata = new Metadata
            {
                TotalCount = pagedClients.TotalCount,
                PageSize = pagedClients.PageSize,
                CurrentPage = pagedClients.CurrentPage,
                TotalPages = pagedClients.TotalPages,
                HasNextPage = pagedClients.HasNextPage,
                HasPreviousPage = pagedClients.HasPreviousPage,
                NextPageUrl = _uriService.GetClientPaginationUri(filters, actionUrl).ToString(),
                PreviousPageUrl = _uriService.GetClientPaginationUri(filters, actionUrl).ToString()
            };


            return ClientsDtos;
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

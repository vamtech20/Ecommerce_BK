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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
         private readonly IUriService _uriService;

        public OrderService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
        }

        public IEnumerable<PurchaseOrderDto> GetPurchaseOrders(PurchaseOrderQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;


            var orders = _unitOfWork.PurchaseOrderRepository.GetAll();
              
            var pagedOrders = PagedList<PurchaseOrder>.Create(orders, filters.PageNumber, filters.PageSize);

            var orderDtos = _mapper.Map<IEnumerable<PurchaseOrderDto>>(pagedOrders);

            metadata = new Metadata
            {
                TotalCount = pagedOrders.TotalCount,
                PageSize = pagedOrders.PageSize,
                CurrentPage = pagedOrders.CurrentPage,
                TotalPages = pagedOrders.TotalPages,
                HasNextPage = pagedOrders.HasNextPage,
                HasPreviousPage = pagedOrders.HasPreviousPage,
                NextPageUrl = _uriService.GetPurchaseOrderPaginationUri(filters, actionUrl).ToString(),
                PreviousPageUrl = _uriService.GetPurchaseOrderPaginationUri(filters, actionUrl).ToString()
            };


            return orderDtos;

        }

        public async Task<PurchaseOrderDto> GetPurchaseOrder(int id)
        {
            var po = await _unitOfWork.PurchaseOrderRepository.GetById(id);
            return _mapper.Map<PurchaseOrderDto>(po);
        }

        public async Task InsertPurchaseOrder(PurchaseOrderDto po)
        {
            var ped = _mapper.Map<PurchaseOrder>(po);
            await _unitOfWork.PurchaseOrderRepository.Add(ped);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdatePurchaseOrder(PurchaseOrderDto po)
        {
            var existingPo = await _unitOfWork.PurchaseOrderRepository.GetById(po.Id);
                   

            _unitOfWork.PurchaseOrderRepository.Update(existingPo);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePurchaseOrder(int id)
        {
            await _unitOfWork.OfferRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}

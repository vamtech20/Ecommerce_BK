using AutoMapper;
using Microsoft.Extensions.Configuration;
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
using VamTech.Ecommerce.Core.Resources;

namespace VamTech.Ecommerce.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;
        private IMailService _mailService;
        private IConfiguration _configuration;

        public OrderService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService, IMailService mailService, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
            _mailService = mailService;
            _configuration = configuration;

        }

        public IEnumerable<PurchaseOrderDto> GetPurchaseOrders(PurchaseOrderQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            filters.CompanyId = filters.CompanyId is null ? 0 : filters.CompanyId;
            filters.Document = filters.Document is null ? 0 : filters.Document;
            filters.StateId = filters.StateId is null ? -1 : filters.StateId;
            filters.OrderDateFrom = filters.OrderDateFrom is null ? DateTime.Now.AddDays(-1825) : filters.OrderDateFrom;
            filters.OrderDateTo = filters.OrderDateTo is null ? DateTime.Now.AddDays(1825) : filters.OrderDateTo;

            var orders = _unitOfWork.PurchaseOrderRepository.GetAll()
                .Where(x => (x.OrderDate >= filters.OrderDateFrom && x.OrderDate <= filters.OrderDateTo)
                        && (x.StateId == filters.StateId || filters.StateId == -1)
                        && ((x.Client.Document.HasValue &&  x.Client.Document == filters.Document) || filters.Document == 0)
                        && (x.CompanyId == filters.CompanyId || filters.CompanyId == 0)
                       );

            orders = orders.OrderByDescending(x => x.OrderDate); 
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
            try
            {
                var ped = _mapper.Map<PurchaseOrder>(po);
                await _unitOfWork.PurchaseOrderRepository.Add(ped);
                await _unitOfWork.SaveChangesAsync();

                //await SendPODetailMail(po);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
        public Task<bool> SendPODetailMail(PurchaseOrderDto po)
        {
            string subj = string.Empty;
            string body = string.Empty;
            string[] recip = new string[1];

            string body_h = string.Empty;
            string body_d = string.Empty;


            recip[0] = po.Client.Email;
            subj = string.Format(Messages.PO_Subject, _configuration["Company"], po.Id);

            body_h = string.Format(Messages.PO_Body_Header, po.OrderDate, po.Client.FirstName, po.TotalInvoiced);
            foreach (var prd in po.Products)
            {
                body_d += "<td>" + prd.Product.Description + "</td><td>" + prd.Product.SalePrice + "</td><td>" + prd.Quantity + "</td><td>" + prd.Product.SalePrice * prd.Quantity;

            }

            return _mailService.SendMail(subj, body, recip);
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

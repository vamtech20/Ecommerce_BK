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
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;

        public OfferService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
        }
        public PagedList<Offer> GetOffers(OfferQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var offers = _unitOfWork.OfferRepository.GetAll();


            var pagedOffers = PagedList<Offer>.Create(offers, filters.PageNumber, filters.PageSize);
            return pagedOffers;
        }
       
    }
}

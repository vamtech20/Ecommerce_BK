﻿using AutoMapper;
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
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
         private readonly IUriService _uriService;

        public OfferService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
        }
        
        public IEnumerable<OfferDto> GetOffers(OfferQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;


            var offers = _unitOfWork.OfferRepository.GetAll().Where(x=> x.IsActive);

            var pagedOffers = PagedList<Offer>.Create(offers, filters.PageNumber, filters.PageSize);

            var offersDtos = _mapper.Map<IEnumerable<OfferDto>>(pagedOffers);

            metadata = new Metadata
            {
                TotalCount = pagedOffers.TotalCount,
                PageSize = pagedOffers.PageSize,
                CurrentPage = pagedOffers.CurrentPage,
                TotalPages = pagedOffers.TotalPages,
                HasNextPage = pagedOffers.HasNextPage,
                HasPreviousPage = pagedOffers.HasPreviousPage,
                NextPageUrl = _uriService.GetOfferPaginationUri(filters, actionUrl).ToString(),
                PreviousPageUrl = _uriService.GetOfferPaginationUri(filters, actionUrl).ToString()
            };


            return offersDtos;

        }


        public IEnumerable<OfferTypeDto> GetOfferTypes()
        {
            var offerTypes = _unitOfWork.OfferTypeRepository.GetAll();
            var offersTypesDtos = _mapper.Map<IEnumerable<OfferTypeDto>>(offerTypes);

            return offersTypesDtos;

        }

        public async Task<Offer> GetOffer(int id)
        {
            return await _unitOfWork.OfferRepository.GetById(id);
        }

        public async Task InsertOffer(Offer Offer)
        {

            await _unitOfWork.OfferRepository.Add(Offer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateOffer(Offer Offer)
        {
            var existingOffer = await _unitOfWork.OfferRepository.GetById(Offer.Id);

            existingOffer.OfferTypeId = Offer.OfferTypeId;
            existingOffer.OfferTypeId = Offer.OfferTypeId;
            existingOffer.ValidFrom = Offer.ValidFrom;
            existingOffer.ValidTo = Offer.ValidTo;
            existingOffer.TotalPriceOffer = Offer.TotalPriceOffer;
            existingOffer.Details = Offer.Details;

            _unitOfWork.OfferRepository.Update(existingOffer);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteOffer(int id)
        {
            await _unitOfWork.OfferRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}

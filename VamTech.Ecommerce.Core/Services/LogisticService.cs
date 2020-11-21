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
    public class LogisticService : ILogisticService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public LogisticService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options, IMapper mapper, IUriService uriService)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
            _mapper = mapper;
            _uriService = uriService;
        }

        
        public IEnumerable<CompanyDto> GetCompanies(CompanyQueryFilter filters, string actionUrl, out Metadata metadata)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;
            filters.IsPos = filters.IsPos is null ? -1 : filters.IsPos;


            var Companies = _unitOfWork.CompanyRepository.GetAll().Where(x => (x.IsPos == filters.IsPos || filters.IsPos == -1)
                                                                           );

            var pagedCompanies = PagedList<Company>.Create(Companies, filters.PageNumber, filters.PageSize);
                        
            var CompaniesDtos = _mapper.Map<IEnumerable<CompanyDto>>(pagedCompanies);
            
            metadata = new Metadata
            {
                TotalCount = pagedCompanies.TotalCount,
                PageSize = pagedCompanies.PageSize,
                CurrentPage = pagedCompanies.CurrentPage,
                TotalPages = pagedCompanies.TotalPages,
                HasNextPage = pagedCompanies.HasNextPage,
                HasPreviousPage = pagedCompanies.HasPreviousPage,
                NextPageUrl = _uriService.GetCompanyPaginationUri(filters, actionUrl).ToString(),
                PreviousPageUrl = _uriService.GetCompanyPaginationUri(filters, actionUrl).ToString()
            };


            return CompaniesDtos;
           
        }

    }
}

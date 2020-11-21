using System;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IUriService
    {
        Uri GetProductPaginationUri(ProductQueryFilter filter, string actionUrl);

        Uri GetCategoryPaginationUri(CategoryQueryFilter filter, string actionUrl);

        Uri GetOfferPaginationUri(OfferQueryFilter filter, string actionUrl);

        Uri GetCompanyPaginationUri(CompanyQueryFilter filter, string actionUrl);
    }
}
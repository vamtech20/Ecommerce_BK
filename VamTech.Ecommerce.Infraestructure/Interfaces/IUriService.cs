using System;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetProductPaginationUri(ProductQueryFilter filter, string actionUrl);

        Uri GetOfferPaginationUri(OfferQueryFilter filter, string actionUrl);
    }
}
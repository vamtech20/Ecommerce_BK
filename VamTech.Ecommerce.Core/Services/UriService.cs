using VamTech.Ecommerce.Core.QueryFilters;
using System;
using VamTech.Ecommerce.Core.Interfaces;

namespace VamTech.Ecommerce.Core.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetProductPaginationUri(ProductQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
        public Uri GetOfferPaginationUri(OfferQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}

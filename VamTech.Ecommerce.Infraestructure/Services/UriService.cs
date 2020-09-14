using VamTech.Ecommerce.Core.QueryFilters;
using VamTech.Ecommerce.Infrastructure.Interfaces;
using System;

namespace VamTech.Ecommerce.Infrastructure.Services
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
    }
}

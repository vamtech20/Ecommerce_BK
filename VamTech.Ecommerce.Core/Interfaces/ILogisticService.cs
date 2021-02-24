using System.Collections.Generic;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface ILogisticService
    {
        IEnumerable<CompanyDto> GetCompanies(CompanyQueryFilter filters, string actionUrl, out Metadata metadata);

        Task<CompanyDto> GetCompany(int id);

        Task InsertCompany(CompanyDto Company);

        Task<bool> UpdateCompany(CompanyDto Company);

        Task<bool> DeleteCompany(int id);

    }
}
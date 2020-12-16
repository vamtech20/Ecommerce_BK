using System.Collections.Generic;
using System.Threading.Tasks;
using VamTech.Ecommerce.Core.CustomEntities;
using VamTech.Ecommerce.Core.DTOs;
using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.QueryFilters;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<PurchaseOrderDto> GetPurchaseOrders(PurchaseOrderQueryFilter filters, string actionUrl, out Metadata metadata);

        Task<PurchaseOrderDto> GetPurchaseOrder(int id);

        Task InsertPurchaseOrder(PurchaseOrderDto po);

        Task<bool> UpdatePurchaseOrder(PurchaseOrderDto Company);

        Task<bool> DeletePurchaseOrder(int id);

    }
}
﻿using System;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IClientRepository ClientRepository { get; }
        IOfferRepository OfferRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        IOfferTypeRepository OfferTypeRepository { get; }

        IBrandRepository BrandRepository { get; }

        ICompanyRepository CompanyRepository { get; }

        IPurchaseOrderRepository PurchaseOrderRepository { get; }

        IPOStateTrackingRepository POStateTrackingRepository { get; }


        void SaveChanges();
                Task SaveChangesAsync();
    }
}

using System;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        IClientRepository ClientRepository { get; }
        IOfferRepository OfferRepository { get; }
        ICategoryRepository CategoryRepository { get; }


        void SaveChanges();
                Task SaveChangesAsync();
    }
}

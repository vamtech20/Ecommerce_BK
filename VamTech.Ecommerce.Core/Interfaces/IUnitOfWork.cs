using System;
using System.Threading.Tasks;

namespace VamTech.Ecommerce.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ISecurityRepository SecurityRepository { get; }


        void SaveChanges();
                Task SaveChangesAsync();
    }
}

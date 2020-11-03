﻿using VamTech.Ecommerce.Core.Entities;
using VamTech.Ecommerce.Core.Interfaces;
using System.Threading.Tasks;
using VamTech.Ecommerce.Infraestructure.Data;
using Vamtech.Ecommerce.Infrastructure.Repositories;

namespace VamTech.Ecommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VamtechEcommerceContext _context;
        
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly ICategoryRepository _categoryRepository;



        public UnitOfWork(VamtechEcommerceContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => _productRepository ?? new ProductRepository(_context);
        public IClientRepository ClientRepository => _clientRepository ?? new ClientRepository(_context);

        public IOfferRepository OfferRepository => _offerRepository ?? new OfferRepository(_context);

        public ICategoryRepository CategoryRepository => _categoryRepository ?? new CategoryRepository(_context);



        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

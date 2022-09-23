using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entitities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        public StoreContext context { get; }
        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {

            return await context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)


            .ToListAsync();

        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()




        {
            return await context.ProductBrands.ToListAsync();

        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await context.ProductTypes.ToListAsync();
        }


    }
}
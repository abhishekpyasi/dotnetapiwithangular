using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Core.Entitities;

namespace Core.Specification
{
    public class ProductsWithProductTypesAndBrands : BaseSpecification<Product>
    {
        public ProductsWithProductTypesAndBrands()
        {

            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

        public ProductsWithProductTypesAndBrands(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

        }
    }
}
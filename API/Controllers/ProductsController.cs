using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Core.Entitities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        public IProductRepository repo { get; }
        public ProductsController(IProductRepository repo)
        {
            this.repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()

        {

            var products = await repo.GetProductsAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {

            return await repo.GetProductByIdAsync(id);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> getProductBrands()
        {

            return Ok(await repo.GetProductBrandsAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductBrand>> getProductTypes()
        {

            return Ok(await repo.GetProductTypesAsync());

        }





    }
}
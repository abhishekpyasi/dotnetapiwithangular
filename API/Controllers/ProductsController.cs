using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Core.Entitities;
using Core.Interfaces;
using Core.Specification;
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

        private readonly IGenricRepository<Product> _productrepo;
        private readonly IGenricRepository<ProductBrand> _productbrandRepo;
        private readonly IGenricRepository<ProductType> _productTyperepo;


        public ProductsController(IGenricRepository<Product> productrepo, IGenricRepository<ProductBrand> productbrandRepo

        , IGenricRepository<ProductType> productTyperepo)
        {
            _productrepo = productrepo;

            _productbrandRepo = productbrandRepo;

            _productTyperepo = productTyperepo;




        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()

        {

            var spec = new ProductsWithProductTypesAndBrands();
            var products = await _productrepo.ListAsync(spec);
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var spec = new ProductsWithProductTypesAndBrands(id);

            return await _productrepo.GetEntityWithSpec(spec);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> getProductBrands()
        {

            return Ok(await _productbrandRepo.ListAllAsync());

        }

        [HttpGet("types")]
        public async Task<ActionResult<ProductBrand>> getProductTypes()
        {

            return Ok(await _productbrandRepo.ListAllAsync());

        }





    }
}
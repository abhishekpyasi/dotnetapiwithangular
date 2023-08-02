using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Core.Entitities;
using Core.Interfaces;
using Core.Specification;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        public IProductRepository repo { get; }

        private readonly IGenricRepository<Product> _productrepo;
        private readonly IGenricRepository<ProductBrand> _productbrandRepo;
        private readonly IGenricRepository<ProductType> _productTyperepo;

        private readonly IMapper _mapper;


        public ProductsController(IGenricRepository<Product> productrepo, IGenricRepository<ProductBrand> productbrandRepo

        , IGenricRepository<ProductType> productTyperepo, IMapper mapper)
        {
            _productrepo = productrepo;

            _productbrandRepo = productbrandRepo;

            _productTyperepo = productTyperepo;

            _mapper = mapper;




        }

        [HttpGet]
        public async Task<ActionResult<List<ProductToReturnDto>>> GetProducts()

        {

            var spec = new ProductsWithProductTypesAndBrands();
            var products = await _productrepo.ListAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> getProduct(int id)
        {
            var spec = new ProductsWithProductTypesAndBrands(id);

            var product = await _productrepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);



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
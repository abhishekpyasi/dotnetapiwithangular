using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOS;
using AutoMapper;
using Core.Entitities;

namespace API.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
    {
        private IConfiguration _Config { get; set; }
        public ProductUrlResolver(IConfiguration config)
        {
            this._Config = config;
        }

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {

            if (!string.IsNullOrEmpty(source.PictureUrl))
            {

                return _Config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Controllers.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
  public class ProductUrlResolver : IValueResolver<Product, ProductToReturnDto, string>
  {
    private IConfiguration _Config;
    public ProductUrlResolver(IConfiguration config)
    {
      _Config = config;
        
    }

    public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
    {
      if(!string.IsNullOrEmpty(source.PictureUrl))
      {
        return _Config["ApiUrl"] + source.PictureUrl;
      }
      return null;
    }
  }
}
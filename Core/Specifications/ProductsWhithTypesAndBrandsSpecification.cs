using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Controllers.Entities;

namespace Core.Specifications
{
  public class ProductsWhithTypesAndBrandsSpecification : BaseSpecification<Product>
  {
    public ProductsWhithTypesAndBrandsSpecification()
    {
        AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);

    }

    public ProductsWhithTypesAndBrandsSpecification(int id) : base(x => x.Id == id)
    {
         AddInclude(x => x.ProductType);
        AddInclude(x => x.ProductBrand);
    }
  }
}
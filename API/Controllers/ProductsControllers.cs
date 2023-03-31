using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Controllers.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase 
    {
       
       private readonly IGenericRepository<Product> _productsRepo;
       private readonly IGenericRepository<ProductBrand> _ProductBrandRepo;
       private readonly IGenericRepository<ProductType> _ProductTypeRepo;
        private readonly IMapper _mapper;

        public ProductsController (IGenericRepository<Product> productsRepo,
         IGenericRepository  <ProductBrand> productsBrandRepo, 
         IGenericRepository<ProductType> productsTypeRepo, IMapper mapper )
        {
           _mapper = mapper;
           _ProductBrandRepo = productsBrandRepo;
           _productsRepo = productsRepo;
           _ProductTypeRepo = productsTypeRepo;
        }
        [HttpGet] 
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWhithTypesAndBrandsSpecification();
            
            var products = await _productsRepo.ListAsync(spec);

            return Ok(_mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>((IReadOnlyList<Product>)products));
        }

         [HttpGet("{id}")] 
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWhithTypesAndBrandsSpecification(id);
            var product =  await _productsRepo.GetEntityWithSpec(spec);
            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

         [HttpGet("Brands")] 
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _ProductBrandRepo.ListAllAsync());
        }
        [HttpGet("Types")] 
          public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _ProductTypeRepo.ListAllAsync());

        }
    }
}
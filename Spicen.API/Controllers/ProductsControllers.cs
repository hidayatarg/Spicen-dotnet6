using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Spicen.Core;
using Spicen.Core.DTOs;
using Spicen.Core.Services;

namespace Spicen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsControllers : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        private readonly IProductService _productService;

        // DI
        public ProductsControllers(IService<Product> service, IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _service = service;
            _productService = productService;
        }

       [HttpGet]
       public async Task<IActionResult> All()
       {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
       }

        // api/products/12
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return CreateActionResult(CustomResponseDto<ProductDto>.Fail(400, $"Product with {id} Not Found"));
            }

            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _service.AddAysnc(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // api/products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            if(product == null)
            {
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404, $"No Product Exists with id={id}"));
            }
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        // api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }
    }
}

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

        // DI
        public ProductsControllers(IService<Product> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

       [HttpGet]
       public async Task<IActionResult> All()
       {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succcess(200, productsDtos));
       }

        // api/products/12
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Succcess(200, productDto));
        }
    }
}

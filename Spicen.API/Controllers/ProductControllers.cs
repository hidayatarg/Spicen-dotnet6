using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Spicen.Core;
using Spicen.Core.DTOs;
using Spicen.Core.Services;

namespace Spicen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;

        // DI
        public ProductControllers(IService<Product> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

       public async Task<IActionResult> All()
       {
            var products = await _service.GetAllAsync();

            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return Ok(CustomResponseDto<List<ProductDto>>.Succcess(200, productsDtos);
       }


        

    }
}

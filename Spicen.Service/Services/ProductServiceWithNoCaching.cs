using AutoMapper;
using Spicen.Core;
using Spicen.Core.DTOs;
using Spicen.Core.Repositories;
using Spicen.Core.Services;
using Spicen.Core.UnitOfWorks;

namespace Spicen.Service.Services
{
    /// <summary>
    /// product specific methods added on the top of GenericServices
    /// </summary>
    public class ProductServiceWithNoCaching : Service<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductServiceWithNoCaching(IGenericRepository<Product> repository, IUnitOfWork unitOfWork, IMapper mapper, IProductRepository productRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            var products = await _productRepository.GetProductsWithCategory();
            var productsDto = _mapper.Map<List<ProductWithCategoryDto>>(products);
            return CustomResponseDto<List<ProductWithCategoryDto>>.Success(200, productsDto);
        }
    }
}

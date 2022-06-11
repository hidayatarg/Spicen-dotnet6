using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Spicen.Core;
using Spicen.Core.DTOs;
using Spicen.Core.Repositories;
using Spicen.Core.Services;
using Spicen.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Spicen.Caching
{
    // proxy design
    public class ProductServiceWithCaching : IProductService
    {
        private const string CacheProductKey = "productsCache";
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductServiceWithCaching(IMapper mapper, IMemoryCache memoryCache, IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
            _unitOfWork = unitOfWork;
            _repository = repository;

            if (!_memoryCache.TryGetValue(CacheProductKey, out _))
            {
                _memoryCache.Set(CacheProductKey, _repository.GetAll().ToList());
            }
        }

        public Task<Product> AddAysnc(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> AddRangeAysnc(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<List<ProductWithCategoryDto>>> GetProductsWithCategory()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}

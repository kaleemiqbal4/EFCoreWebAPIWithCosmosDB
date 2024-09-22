using EFCoreCosmosDB.Application.Contract;
using EFCoreCosmosDB.Entity.Entity;
using EFCoreCosmosDB.Entity.Reponse;
using EFCoreCosmosDB.Entity.Request;
using EFCoreCosmosDB.Repository.Integration.Contract;
using Microsoft.Extensions.Logging;

namespace EFCoreCosmosDB.Application.Concrete;

public class ProductManager : IProductManager
{
    private readonly IProductRepository productRepository;
    private readonly ILogger<ProductManager> logger;

    public ProductManager(IProductRepository _productRepository, ILogger<ProductManager> _logger) => (productRepository, logger) = (_productRepository, _logger);

    public async Task<int> CreateProductAsync(ProductRequest request)
    {
        ProductEntity pe = new ProductEntity
        {
            Id = "2",
            Name = request.Name,
            Price = request.Price,
            Description = request.Description,
        };
        var result = await productRepository.AddAsync(pe);
        return 1;
    }

    public async Task<List<ProductResponse>> ProductListAsync()
    {
        var result = await productRepository.GetAllAsync();
        var products = new List<ProductResponse>();
        result.ToList().ForEach(p => products.Add(new ProductResponse()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description
        }));
        return products;
    }
}

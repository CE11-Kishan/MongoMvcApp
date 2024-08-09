using MongoDB.Driver;

namespace MongoMvcApp.Models
{
      public class ProductRepository
      {
            private readonly IMongoCollection<Product> _products;

            public ProductRepository(IMongoDatabase database)
            {
                  _products = database.GetCollection<Product>("Products");
            }

            public async Task<List<Product>> GetProductsAsync() =>
                await _products.Find(product => true).ToListAsync();

            public async Task<Product> GetProductAsync(string id) =>
                await _products.Find(product => product.Id == id).FirstOrDefaultAsync();

            public async Task CreateProductAsync(Product product) =>
                await _products.InsertOneAsync(product);

            public async Task UpdateProductAsync(string id, Product productIn) =>
                await _products.ReplaceOneAsync(product => product.Id == id, productIn);

            public async Task RemoveProductAsync(string id) =>
                await _products.DeleteOneAsync(product => product.Id == id);
      }
}

using CodeTestQHRM.Interface;
using CodeTestQHRM.Models;
using Dapper;
using System.Data;

namespace CodeTestQHRM.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var query = "SELECT * FROM Products";
        return (await _connection.QueryAsync<Product>(query)).AsList();
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var query = "SELECT * FROM Products WHERE Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<Product>(query, new { Id = id });
    }

    public async Task AddProductAsync(Product product)
    {
        product.CreatedDate = DateTime.UtcNow;
        var query = $"INSERT INTO Products (Name, Description, CreatedDate) VALUES (@Name, @Description , @CreatedDate)";
        await _connection.ExecuteAsync(query, product);
    }

    public async Task UpdateProductAsync(Product product)
    {
        product.UpdatedDate = DateTime.UtcNow;
        var query = $"UPDATE Products SET Name = @Name, Description = @Description , UpdatedDate = @UpdatedDate  WHERE Id = @Id";
        await _connection.ExecuteAsync(query, product);
    }

    public async Task DeleteProductAsync(int id)
    {
        var query = "DELETE FROM Products WHERE Id = @Id";
        await _connection.ExecuteAsync(query, new { Id = id });
    }
}


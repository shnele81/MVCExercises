using System.Collections.Generic;
using System.Data;
using Dapper;
using MVC_Exercises.Models;

namespace MVC_Exercises.Data;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _connection;

    public ProductRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return _connection.Query<Product>("SELECT * FROM Products");
    }
    public Product GetProduct(int id)
    {
        return _connection.QuerySingle<Product>("SELECT * FROM Products WHERE ProductId = @id", new { id = id });
    }
}
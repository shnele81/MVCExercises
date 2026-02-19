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

    public void UpdateProduct(Product product)
    {
        _connection.Execute("UPDATE Products SET Name = @name AND Price = @price WHERE ProductId = @ProductId",
            new { name = product.Name, price = product.Price, ProductId = product.ProductId });
    }

    public void InsertProduct(Product productToInsert)
    {
        _connection.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
            new {name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryId });
    }
    public IEnumerable<Category> GetCategories()
    {
        return _connection.Query<Category>("SELECT * FROM categories;");
    }
    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }
    public void DeleteProduct(Product product)
    {
        _connection.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new {id = product.ProductId });
        _connection.Execute("DELETE FROM Sales WHERE ProductID = @id;",  new { id = product.ProductId });
        _connection.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductId });
    }
}
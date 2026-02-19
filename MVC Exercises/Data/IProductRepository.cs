using System;
using System.Collections.Generic;
using MVC_Exercises.Models;

namespace MVC_Exercises.Data;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts(); 
    Product GetProduct(int id);
    public void UpdateProduct(Product product);
    public void InsertProduct(Product productToInsert);
    public IEnumerable<Category> GetCategories();
    public Product AssignCategory();
    public void DeleteProduct(Product product);

}
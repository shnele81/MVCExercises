using Microsoft.AspNetCore.Mvc;
using MVC_Exercises.Data;

namespace MVC_Exercises.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // GET
    public IActionResult Index()
    {
        var products = _productRepository.GetAllProducts();
        return View(products);
    }
}
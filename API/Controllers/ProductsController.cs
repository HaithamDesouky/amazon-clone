using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

  public class ProductsController : BaseApiController
  {
    private readonly DataContext _context;
    public ProductsController(DataContext context)
    {
      _context = context;

    }

    [HttpGet]

       public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      
        return await _context.Products.ToListAsync();

    }
  

    // public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string sort )
    // {

    //   var allProducts = await _productsRepo.GetAllProductsAsync(sort);

    //       var Products = allProducts.AsQueryable();
    //   if(!string.IsNullOrEmpty(sort)){
        
    //     switch(sort)
    //     {
    //       case "priceasc":
    //       Products = Products.OrderBy(x => x.price);
    //       break;
    //       case "pricedesc":
    //       Products = Products.OrderByDescending(x => x.price);
    //       break;
    //       case "nameasc":
    //       Products = Products.OrderBy(x => x.name);
    //       break;
    //       case "namedesc":
    //       Products = Products.OrderByDescending(x => x.name);
    //       break;
    //     }


    //   }

    //   return Products.ToList();
    // }


    [HttpGet("{id}")]

    public async Task<ActionResult<Product>> GetProduct(int id )
    {


      var product = await _context.Products.FindAsync(id);


      return product;
    }


  }
}
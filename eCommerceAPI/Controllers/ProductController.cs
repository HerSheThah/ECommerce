using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ECommerceContext _context;
        public ProductController(ECommerceContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            List<Product> products= await _context.Products.ToListAsync();
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _context.Products.FindAsync(id);
        }

    }
}

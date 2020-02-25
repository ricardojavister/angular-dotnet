using System.Linq;
using apiapp.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace apiapp.Controllers
{
     [Route("api/[controller]")]
    public class productController : Controller
    {
        private readonly MyDbContext _context;

        public productController(MyDbContext context){
            this._context = context;
        }

        [HttpGet]   
        [Route("getAll")]
        public IQueryable<product> getAll(){
            return _context.Product.AsQueryable();
        }

        [HttpPost]
        public IActionResult insert([FromBody] product product){
            _context.Product.Add(product);
            var result = _context.SaveChanges();
            return Ok(result);
        }
   
    }
}
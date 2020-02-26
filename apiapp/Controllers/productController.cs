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

        [HttpGet]   
        [Route("getById")]
        public IQueryable<product> getById(int idProduct){
            return _context.Product.Where(x=> x.idproduct==idProduct).AsQueryable();
        }

        [HttpPost]
        public IActionResult insert([FromBody] product product){
            _context.Product.Add(product);
            var result = _context.SaveChanges();
            return Ok(result);
        }

        [HttpPut]
        public IActionResult update([FromBody] product product){
            _context.Product.Update(product);
            product entityFound =  this.getById(product.idproduct).FirstOrDefault();
            entityFound.productName = product.productName;
            entityFound.price = product.price;
            return Ok(_context.SaveChanges());
        }

        [HttpDelete]
        public IActionResult delete(int idProduct){
            product entityFound =  this.getById(idProduct).FirstOrDefault();
            _context.Product.Remove(entityFound);
            return Ok(_context.SaveChanges());
        }
   
    }
}
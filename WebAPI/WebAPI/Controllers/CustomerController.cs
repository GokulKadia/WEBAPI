using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;
using System.Security.AccessControl;
using WebAPI.Data;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApiDBContext _context;

        public CustomerController(ApiDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomer()
        {
            return Ok(await _context.customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomer(int id) {
            var cust = _context.customers.Find(id);
            if (cust == null) { return NotFound(); }
            return cust;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Create(Customer customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,Customer customer)
        {
            if (id != customer.id) return BadRequest();
            _context.Entry(customer).State= EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cust=await _context.customers.FindAsync(id);
                
            if (cust==null) return NotFound("Incorrect Customer ID");
            _context.customers.Remove(cust);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

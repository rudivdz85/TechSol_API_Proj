using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSol_API_Proj.Interfaces;
using TechSol_API_Proj.Models;

namespace TechSol_API_Proj.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IDatabaseOperations _dbOperations;

        public CustomersController(IDatabaseOperations dbOperations)
        {
            _dbOperations = dbOperations;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] Customer customer)
        {
            _dbOperations.AddCustomer(customer.FirstName, customer.LastName, customer.DateOfBirth);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _dbOperations.GetCustomer(id);
            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            var customers = _dbOperations.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            _dbOperations.UpdateCustomer(id, customer.FirstName, customer.LastName);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            _dbOperations.DeleteCustomer(id);
            return Ok();
        }
    }
}

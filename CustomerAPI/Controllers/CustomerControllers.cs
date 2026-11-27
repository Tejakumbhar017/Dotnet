using Microsoft.AspNetCore.Mvc;
using CustomerAPI.Entities;
using CustomerAPI.Repositories;
using CustomerAPI.Services;
namespace CustomerAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private ICustomerServices _service;

     public CustomersController(ICustomerServices svc)
    {
        this._service=svc;
    }

    [HttpGet]
    public List<Customer> GetAll()
    {
        List<Customer> customers = new List<Customer>();
    
        customers = this._service.GetAll();
        return customers;
    }

    [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {

            Customer customer = _service.GetById(id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            return Ok(customer);
        }
    [HttpPost]
    public ActionResult<Customer> Add(Customer customer)
    {
       

        this._service.Create(customer);

        return customer;
    }

     [HttpPut("{id}")]
    public IActionResult Update(int id, Customer customer)
    {
        if (id != customer.Id)
        {
            return BadRequest("Customer ID mismatch");
        }

        bool result = _service.Update(customer , id);

        if (!result)
        {
            return NotFound("Customer not found");
        }

        return Ok("Customer updated successfully");
    }

    // DELETE: api/customers/1
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        

        bool result = _service.Delete(id);

        if (!result)
        {
            return NotFound("Customer not found");
        }

        return Ok("Customer deleted successfully");
    }

}

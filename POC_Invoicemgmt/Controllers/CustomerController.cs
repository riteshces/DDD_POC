using Amazon.Runtime.Internal;
using App.Application.Customer.Commands.CreateCustomer;
using App.Application.Customer.Commands.UpdateCustomer;
using App.Application.Customer.Queries.GetCustomerById;
using App.Application.Customer.Queries.GetCustomers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Invoicemgmt.Common;

namespace POC_Invoicemgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : APIControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await Mediator.Send(new GetCustomersQuery());
            var result = new ApiResponse<List<CustomerViewModel>>("Success", 200, customers);
            return Ok(result);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            var customer = await Mediator.Send(new GetCustomerByIdQuery { Id = id });
            if (customer == null)
            {
                return NotFound(new ApiResponse<string>("Not Found", 404, "No data found"));
            }
            var result = new ApiResponse<CustomerViewModel>("Success", 200, customer);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(CreateCustomerCommand customer)
        {
            var rescustomer = await Mediator.Send(customer);
            var result = new ApiResponse<CustomerViewModel>("Success", 200, rescustomer);
            return Ok(result);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateCustomer(string id, UpdateCustomerCommand customer)
        {
            if (id == null)
            {
                return BadRequest(new ApiResponse<string>("Error", 400, "Id must not be empty."));
            }
            if (id != customer.Id)
            {
                return BadRequest(new ApiResponse<string>("Error", 400, "Id mismatch."));
            }
            var result = await Mediator.Send(customer);
            return Ok(new ApiResponse<CustomerViewModel>("Success", 200, result));
        }
    }
}

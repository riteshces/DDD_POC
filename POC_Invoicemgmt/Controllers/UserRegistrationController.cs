using App.Application.Customer.Commands.UpdateCustomer;
using App.Application.Customer.Queries.GetCustomers;
using App.Application.UserRegistrations.Commands.CreateUser;
using App.Application.UserRegistrations.Commands.UpdateUser;
using App.Application.UserRegistrations.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using POC_Invoicemgmt.Common;

namespace POC_Invoicemgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : APIControllerBase
    {
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await Mediator.Send(new UserRegistrationQuery { Id = id });
            if(user is null)
            {
                return NotFound(new ApiResponse<string>("Not Found", 404, "No data found"));
            }
            var result = new ApiResponse<UserRegistrationViewModel>("Success", 200, user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserCommand createUserCommand)
        {
            var user = await Mediator.Send(createUserCommand);
            var result = new ApiResponse<UserRegistrationViewModel>("Success", 200, user);
            return Ok(result);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserCommand updateCustomerCommand)
        {
            if (id == null)
            {
                return BadRequest(new ApiResponse<string>("Error", 400, "Id must not be empty."));
            }
            if (id != updateCustomerCommand.Id)
            {
                return BadRequest(new ApiResponse<string>("Error", 400, "Id mismatch."));
            }
            var result = await Mediator.Send(updateCustomerCommand);
            return Ok(new ApiResponse<UserRegistrationViewModel>("Success", 200, result));
        }
    }
}

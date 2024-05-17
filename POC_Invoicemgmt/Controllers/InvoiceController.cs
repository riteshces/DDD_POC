using App.Application.Customer.Queries.GetCustomerById;
using App.Application.Customer.Queries.GetCustomers;
using App.Application.Invoice.Commands.CreateInvoice;
using App.Application.Invoice.Commands.UpdateInvoice;
using App.Application.Invoice.Queries.GetInvoiceById;
using App.Application.Invoice.Queries.GetInvoices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POC_Invoicemgmt.Common;

namespace POC_Invoicemgmt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : APIControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllInvoices()
        {
            var invoices = await Mediator.Send(new GetInvoicesQuery());
            var result = new ApiResponse<List<InvoiceViewModel>>("Success", 200, invoices);
            return Ok(result);
        }

        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetInvoiceById(string id)
        {
            var invoice = await Mediator.Send(new GetInvoiceByIdQuery { Id=id});
            if (invoice == null)
            {
                return NotFound(new ApiResponse<string>("Not Found", 404, "No data found"));
            }
            var result = new ApiResponse<InvoiceViewModel>("Success", 200, invoice);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewInvoice(CreateInvoiceCommand createInvoice)
        {
            var customer = Mediator.Send(new GetCustomerByIdQuery { Id = createInvoice.Customer.Id });
            if (customer == null)
            {
                return BadRequest(new ApiResponse<string>("Error", 400, "Wrong Customer ID"));
            }

            var invoice = await Mediator.Send(createInvoice);
            var result = new ApiResponse<InvoiceViewModel>("Success", 200, invoice);
            return Ok(result);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateInvoice(UpdateInvoiceCommand updateInvoice)
        {
            var customer = Mediator.Send(new GetCustomerByIdQuery { Id = updateInvoice.Customer.Id });
            if (customer == null)
            {
                return BadRequest(new ApiResponse<string>("Error", 400, "Wrong Customer ID"));
            }
            var invoice = await Mediator.Send(updateInvoice);
            var result = new ApiResponse<InvoiceViewModel>("Success", 200, invoice);
            return Ok(result);
        }
    }
}

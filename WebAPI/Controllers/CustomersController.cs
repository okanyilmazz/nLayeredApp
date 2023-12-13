using Business.Abstracts;
using Business.Dtos.Requests;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCustomerRequest createProductRequest)
        {
            var result = await _customerService.AddAsync(createProductRequest);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _customerService.GetListAsync(pageRequest);
            return Ok(result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest updateProductRequest)
        {
            var result = await _customerService.UpdateAsync(updateProductRequest);
            return Ok(result);
        }
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteCustomerRequest deleteProductRequest)
        {
            await _customerService.DeleteAsync(deleteProductRequest);
            return Ok();
        }
    }
}

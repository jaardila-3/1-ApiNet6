using CustomersApi.Dtos;
using CustomersApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerDataBaseContext _dataContext;

        public CustomerController(CustomerDataBaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        //api/customer
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CustomerDto>))]
        public async Task<IActionResult> GetCustomers()
        {
            throw new NotImplementedException();
        }

        //api/customer/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(CustomerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCustomer(int id)
        {
            CustomerEntity result = await _dataContext.Get(id);
            return Ok(result.ToDto());
        }

        //api/customer/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> DeleteCustomer(long id)
        {
            throw new NotImplementedException();
        }

        //api/customer
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CustomerDto))]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDto customer)
        {
            CustomerEntity result = await _dataContext.Add(customer);

            return new CreatedResult($"https://localhost:7014/api/customer/{result.Id}", null);
        }

        //api/customer
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<bool> UpdateCustomer(CustomerDto customer)
        {
            throw new NotImplementedException();
        }
    }
}

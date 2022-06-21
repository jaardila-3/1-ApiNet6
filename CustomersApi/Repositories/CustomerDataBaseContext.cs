using CustomersApi.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDataBaseContext : DbContext
    {
        public CustomerDataBaseContext(DbContextOptions<CustomerDataBaseContext> options)
            : base(options)
        {
        }
        public DbSet<CustomerEntity> Customer { get; set; }

        public async Task<CustomerEntity> Get(int id)
        {
            try
            {
                return await Customer.FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            EntityEntry<CustomerEntity> response;
            CustomerEntity entity = new CustomerEntity()
            {
                Id = null,
                Address = customerDto.Address,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Phone = customerDto.Phone,
            };
            try
            {
                response = await Customer.AddAsync(entity);
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return await Get(response.Entity.Id ?? throw new Exception("No se pudo guardar"));
        }
    }
}

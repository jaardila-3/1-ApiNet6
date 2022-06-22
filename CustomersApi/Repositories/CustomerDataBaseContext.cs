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

        public async Task<CustomerEntity?> Get(int id)
        {
            try
            {
                return await Customer.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            CustomerEntity? entity = await Get(id);
            if (entity == null)
                return false;
            Customer.Remove(entity);
            await SaveChangesAsync();
            return true;
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
                return await Get(response.Entity.Id ?? throw new Exception("No se pudo guardar"));
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public async Task<bool> Actualizar(CustomerEntity customerEntity)
        {
            Customer.Update(customerEntity);
            await SaveChangesAsync();
            return true;
        }
    }
}

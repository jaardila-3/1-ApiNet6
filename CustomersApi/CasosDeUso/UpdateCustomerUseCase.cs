using CustomersApi.Dtos;
using CustomersApi.Repositories;

namespace CustomersApi.CasosDeUso
{
    public class UpdateCustomerUseCase: IUpdateCustomerUseCase
    {
        private readonly CustomerDataBaseContext _dataContext;

        public UpdateCustomerUseCase(CustomerDataBaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CustomerDto?> Execute(CustomerDto customer)
        {
            var entity = await _dataContext.Get(customer.Id);

            if(entity == null)
                return null;

            entity.FirstName = customer.FirstName;
            entity.LastName = customer.LastName;
            entity.Email = customer.Email;
            entity.Phone = customer.Phone;
            entity.Address = customer.Address;

            await _dataContext.Actualizar(entity);
            return entity.ToDto();
        }
    }
}

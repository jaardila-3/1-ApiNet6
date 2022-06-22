using CustomersApi.Dtos;

namespace CustomersApi.CasosDeUso
{
    public interface IUpdateCustomerUseCase
    {
        Task<CustomerDto?> Execute(CustomerDto customer);
    }
}

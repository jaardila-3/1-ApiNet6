using CustomersApi.Dtos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersApi.Repositories
{
    public class CustomerEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

        public CustomerDto ToDto()
        {
            return new CustomerDto
            {
                Address = Address,
                Email = Email,
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Id = Id ?? throw new ArgumentNullException(nameof(Id))
            };
        }
    }
}

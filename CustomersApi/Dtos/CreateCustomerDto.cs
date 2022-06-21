using System.ComponentModel.DataAnnotations;

namespace CustomersApi.Dtos
{
    public class CreateCustomerDto
    {
        [Required(ErrorMessage ="Agregar nombre")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Apellido nombre")]
        public string LastName { get; set; }
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",
            ErrorMessage ="El email no es correcto")]
        public string Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
    }
}

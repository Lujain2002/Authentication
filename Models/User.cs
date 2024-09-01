using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Authentication.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [DataType(DataType.Password)]
        public int? Password { get; set; }
        public bool IsActive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace JsonPropertyNameInValidation
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } 
    }
}
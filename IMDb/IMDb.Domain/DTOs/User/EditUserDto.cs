using System;
using System.ComponentModel.DataAnnotations;

namespace IMDb.Domain.DTOs.User
{
    public class EditUserDto
    {
        [Required(ErrorMessage = "The {0} field is required")]
        public Guid? Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

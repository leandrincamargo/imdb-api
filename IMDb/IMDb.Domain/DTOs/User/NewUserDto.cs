using System;

namespace IMDb.Domain.DTOs.User
{
    public class NewUserDto
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public bool Status { get; set; }

        public Entities.User DtoToEntity()
        {
            return new Entities.User()
            {
                FirstName = FirstName,
                SecondName = SecondName,
                Email = Email,
                Password = Password,
                RoleId = RoleId,
                Status = Status                
            };
        }
    }
}

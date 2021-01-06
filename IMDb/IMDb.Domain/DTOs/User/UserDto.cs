using System;

namespace IMDb.Domain.DTOs.User
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public Guid RoleId { get; set; }
        public RoleDto Role { get; set; }

        public UserDto(Entities.User user)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            SecondName = user.SecondName;
            Email = user.Email;
            Status = user.Status;
            RoleId = user.RoleId;
            Role = new RoleDto(user.Role);
        }
    }
}

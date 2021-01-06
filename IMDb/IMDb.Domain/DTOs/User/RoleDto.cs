using System;

namespace IMDb.Domain.DTOs.User
{
    public class RoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public RoleDto(Entities.Role role)
        {
            Id = role.Id;
            Name = role.Name;
        }
    }
}

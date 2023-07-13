﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Library.Entities
{
    [Table("Users", Schema = "SEC")]
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}

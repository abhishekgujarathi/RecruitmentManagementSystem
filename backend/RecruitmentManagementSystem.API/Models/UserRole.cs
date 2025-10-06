﻿using System.ComponentModel.DataAnnotations;

namespace RecruitmentManagementSystem.API.Models
{
    public class UserRole
    {
        // UserRole(URid, RoleName, active) , pk[URid]
        [Key]
        public Guid UserRoleId { get; set; }
        public string? RoleName { get; set; }
        public bool active { get; set; } = true;

        // if needed to get users of sepcificrole 
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}

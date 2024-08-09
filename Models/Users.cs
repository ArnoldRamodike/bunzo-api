using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AuthSystem.Models
{
    public class Users : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
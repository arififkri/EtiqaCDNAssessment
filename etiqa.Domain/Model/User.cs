using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etiqa.Domain.Model
{
    public class User
    {
       
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string PhoneNumber { get; set; }

        public string? Skillsets { get; set; }

        public string? Hobby { get; set; }
        public string Role { get; set; }
    }
}

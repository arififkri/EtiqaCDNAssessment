using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etiqa.Domain.Model
{
    public class AuthenticatedUser
    {
        public string Token { get; set; }
        public string? UserName { get; set; }
    }
}

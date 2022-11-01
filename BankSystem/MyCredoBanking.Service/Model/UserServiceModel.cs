using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCredoBanking.Service.Model
{
    public class UserServiceModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IdNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

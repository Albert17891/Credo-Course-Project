using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCredoBanking.Service.Model
{
    public class UserAccountServiceModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CardId { get; set; }
        public string Iban { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCredoBanking.Service.Model
{
    public class CreditCardServiceModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int AccountId { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpireDate { get; set; }
        public int Cvv { get; set; }
        public int Pin { get; set; }
    }
}

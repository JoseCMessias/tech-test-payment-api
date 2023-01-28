using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Models.Dtos.Validations
{
    public class VendaDetailsDto
    {
        public DateTime Data { get; set; }
        public int IdVenda { get; set; }
        //public List<Item> ItemVendido { get; set; } 
    }
}
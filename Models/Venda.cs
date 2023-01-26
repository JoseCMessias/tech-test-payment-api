using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Venda : Vendedor
    {
        public int IdDoPedido { get; set; }
        public int IdDoItem { get; set; }
        public DateTime Data { get; set; }
    }
}

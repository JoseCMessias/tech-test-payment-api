using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Models
{
    public class Venda : Vendedor
    {
        // Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;

        public int IdDoPedido { get; set; }
        public int IdDoItem { get; set; }
        public DateTime Data { get; set; }
        public Vendedor Vendedor { get; set; }
    }
}
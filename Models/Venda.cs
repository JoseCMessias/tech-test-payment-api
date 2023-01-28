using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Models
{
    public class Venda : Vendedor
    {
        public DateTime Date { get; set; }
        public int IdVenda { get; set; }
        public StatusVenda StatusVenda { get; set; }

        //public List<Item> ItemVendido { get; set; }        
    }
}
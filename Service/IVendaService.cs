using tech_test_payment_api.Models;

namespace tech_test_payment_api.Service
{
    public interface IVendaService
    {
        public Venda BuscarVenda(int id);
        public void Create(Venda venda);
        public void Update(int id, Venda venda);
    }
}

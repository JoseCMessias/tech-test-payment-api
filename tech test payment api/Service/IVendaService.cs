using tech_test_payment_api.Dtos.InputModel;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Service
{
    public interface IVendaService
    {
        public Venda BuscarVenda(int id);
        public void Create(VendaInputModel vendaInputModel);        
        public void Update(int id, VendaUpdateInputModel vendaUpdateInputModel);
    }
}

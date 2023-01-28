using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Repositories
{
    public interface IVendaRepository
    {
        public Venda BuscarVenda(int id);
        public void Create(Venda venda);
        public void Update(Venda vendaAtual, Venda venda);
    }
}
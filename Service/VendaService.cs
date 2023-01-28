using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tech_test_payment_api.Helpers;
using tech_test_payment_api.Models;
using tech_test_payment_api.Repositories;

namespace tech_test_payment_api.Service
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;

        public VendaService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public Venda BuscarVenda(int id)
        {
            return _vendaRepository.BuscarVenda(id);
        }

        public void Create(Venda venda)
        {
            _vendaRepository.Create(venda);
        }

        public void Update(int id, Venda venda)
        {
            var result = BuscarVenda(id);
            if (result is null)
                throw new Exception("Venda não existe");

            ValideStatusPermit(result, venda);

            _vendaRepository.Update(result, venda);
        }

        private static void ValideStatusPermit(Venda result, Venda venda)
        {
            var state = StateMachine.VerifyStatusPermit(result.StatusVenda, venda.StatusVenda);
            if (!state)
                throw new Exception($"Status da venda incoerente." +
                    $" Não é possível atualizar a venda de {result.StatusVenda} para {venda.StatusVenda}");
        }
    }
}
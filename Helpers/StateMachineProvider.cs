using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Helpers
{
    public class StateMachineProvider
    {
        public StateMachineProvider()
        {
            StatusVenda.AguardandoPagamento.Configure(new List<StatusVenda> { StatusVenda.PagamentoAprovado, StatusVenda.Cancelado });
            StatusVenda.PagamentoAprovado.Configure(new List<StatusVenda> { StatusVenda.EnviadoTransportadora, StatusVenda.Cancelado });
            StatusVenda.EnviadoTransportadora.Configure(new List<StatusVenda> { StatusVenda.Entregue });
        }
    }
}

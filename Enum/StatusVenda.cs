using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tech_test_payment_api.Enum
{
    public enum StatusVenda
    {
        AguardandoPagamento,
        PagamentoAprovado,
        Cancelado,
        EnviadoTransportadora,
        Entregue
    }
}
using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Helpers
{
    public static class StateMachine
    {
        private static readonly Dictionary<StatusVenda, List<StatusVenda>> _states = new();
        public static void Process(StatusVenda statusVenda, List<StatusVenda> permit)
        {
            statusVenda.Configure(permit);
        }
        public static void Configure(this StatusVenda statusVenda, List<StatusVenda> statusVendasPermit)
        {
            _states.Add(statusVenda, statusVendasPermit);
        }
        public static bool VerifyStatusPermit(this StatusVenda statusVendaAtual,
            StatusVenda statusAtualRecebido)
        {
            var result = _states.ContainsKey(statusVendaAtual);
            if (result)
                return _states[statusVendaAtual].Contains(statusAtualRecebido);
            return false;
        }

    }
}

using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Dtos.ViewModel
{
    public class VendaViewModel
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Data { get; set; }
        public int IdVenda { get; set; }
        public StatusVenda StatusVenda { get; set; }
    }
}

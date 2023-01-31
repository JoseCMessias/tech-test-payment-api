using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Dtos.InputModel
{
    public class VendaUpdateInputModel
    {
        public DateTime Date { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public StatusVenda StatusVenda { get; set; }
    }
}
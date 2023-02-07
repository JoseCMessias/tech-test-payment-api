namespace tech_test_payment_api.Dtos.InputModel
{
    public class VendaInputModel
    {
        public DateTime Date { get; set; }
        public int IdVendedor { get; set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }
}
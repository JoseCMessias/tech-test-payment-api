using tech_test_payment_api.Dtos.InputModel;
using tech_test_payment_api.Enum;

namespace tech_test_payment_api.Models
{
    public class Venda : Vendedor
    {
        public DateTime Date { get; set; }
        public int IdVenda { get; set; }
        public StatusVenda StatusVenda { get; set; }

        public static Venda MappingFrom(VendaInputModel vendaInputModel) =>
            new()
            {
                Cpf = vendaInputModel.Cpf,
                Date = vendaInputModel.Date,
                Email = vendaInputModel.Email,
                IdVendedor = vendaInputModel.IdVendedor,
                Nome = vendaInputModel.Nome,
                StatusVenda = StatusVenda.AguardandoPagamento,
                Telefone = vendaInputModel.Telefone,
            };

        public static Venda MappingFrom(VendaUpdateInputModel vendaUpdateInputModel, Venda result) =>
            new()
            {
                IdVenda = result.IdVenda,
                IdVendedor = result.IdVendedor,
                Cpf = vendaUpdateInputModel.Cpf,
                Date = vendaUpdateInputModel.Date,
                Email = vendaUpdateInputModel.Email,
                Nome = vendaUpdateInputModel.Nome,
                StatusVenda = vendaUpdateInputModel.StatusVenda,
                Telefone = vendaUpdateInputModel.Telefone,
            };       
    }
}
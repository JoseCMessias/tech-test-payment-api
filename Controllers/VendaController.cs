using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }

        // Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
        [HttpPost("RegistrarVenda")] //Post envia
        public IActionResult RegistrarVenda(Venda venda)
        {
            _context.Add(venda);
            _context.SaveChanges();

            return Ok("Aguardando pagamento");
            // return Ok(venda);
        }

        // Buscar venda: Busca pelo Id da venda;
        [HttpGet("BuscarVenda/{id}")]
        public IActionResult BuscarVenda(int id)
        {
            var venda = _context.Vendas.Find(id);

            if (venda == null)
            {
                return NotFound();
            }
            return Ok(venda);
        }

        /* Atualizar venda: Permite que seja atualizado o status da venda.
        OBS.: Possíveis status: Pagamento aprovado | Enviado para transportadora | Entregue | Cancelada.
        */
        [HttpPut("AtualizarVenda/{id}")]
        public IActionResult AtualizarVenda(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(id);

            if (vendaBanco == null)
            {
                return NotFound();
            }

            vendaBanco.Nome = venda.Nome;
            vendaBanco.CPF = venda.CPF;
            vendaBanco.Telefone = venda.Telefone;
            vendaBanco.Id = venda.Id;
            vendaBanco.IdDoItem = venda.IdDoItem;
            vendaBanco.IdDoPedido = vendaBanco.IdDoPedido;

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();

            return Ok(vendaBanco);
        }
    }
}
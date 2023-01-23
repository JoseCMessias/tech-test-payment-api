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

            if (venda.Id == null)
            {
                return NotFound();
            }

            // return Ok(venda);
            return Ok("Aguardando pagamento");
        }

        // Buscar venda: Busca pelo Id da venda;
        [HttpGet("{id}")]
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
        [HttpPut("AtualizarVenda")]
        public IActionResult AtualizarVenda()
        {
            return Ok();
        }
    }
}
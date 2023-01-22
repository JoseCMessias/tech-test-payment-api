using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        // Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
        [HttpPost("RegistrarVenda")]
        public IActionResult RegistrarVenda()
        {
            return Ok();
        }

        // Buscar venda: Busca pelo Id da venda;
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult BuscarVenda(int id)
        {
            return Ok();
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
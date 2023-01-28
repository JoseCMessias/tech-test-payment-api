using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Context;
using tech_test_payment_api.Models;
using tech_test_payment_api.Service;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpPost("Create")]
        public IActionResult Create(Venda venda)
        {
            try
            {
                _vendaService.Create(venda);

                return Ok("Aguardando Pagamento");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpGet("BuscarVenda/{id}")]
        public IActionResult BuscarVenda(int id)
        {
            try
            {
                var vendaAtual = _vendaService.BuscarVenda(id);

                if (vendaAtual is null)
                    return NotFound();
                else
                    return Ok(vendaAtual);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, Venda venda)
        {
            try
            {
                _vendaService.Update(id, venda);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}

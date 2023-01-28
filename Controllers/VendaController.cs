using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Models;
using tech_test_payment_api.Models.Dtos.Validations;
using tech_test_payment_api.Service;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService vendaService)
        {
            _vendaService = vendaService;
        }

        [HttpGet("BuscarVenda/{id}")]
        public IActionResult BuscarVenda(int id)
        {
            try
            {
                var vendaAtual = _vendaService.BuscarVenda(id);

                var VendedorRetorno = new VendedorDetailsDto
                {
                    Nome = vendaAtual.Nome,
                    Cpf = vendaAtual.Cpf,
                    Telefone = vendaAtual.Telefone,
                    Email = vendaAtual.Email,
                    Data = vendaAtual.Date,
                    IdVenda = vendaAtual.IdVenda
                };

                if (VendedorRetorno is null)
                    return NotFound();
                else
                    return Ok(VendedorRetorno);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
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

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] Venda venda)
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
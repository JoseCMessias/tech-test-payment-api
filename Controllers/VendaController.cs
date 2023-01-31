using Microsoft.AspNetCore.Mvc;
using tech_test_payment_api.Dtos.InputModel;
using tech_test_payment_api.Dtos.ViewModel;
using tech_test_payment_api.Helpers;
using tech_test_payment_api.Service;

namespace tech_test_payment_api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly StateMachineProvider _stateMachineProvider;

        public VendaController(IVendaService vendaService,
            StateMachineProvider stateMachineProvider)
        {
            _vendaService = vendaService;
            _stateMachineProvider = stateMachineProvider;

        }

        [HttpGet("BuscarVenda/{id}")]
        public IActionResult BuscarVenda(int id)
        {
            try
            {
                var vendaAtual = _vendaService.BuscarVenda(id);

                var VendedorRetorno = new VendaViewModel
                {
                    Nome = vendaAtual.Nome,
                    Cpf = vendaAtual.Cpf,
                    Telefone = vendaAtual.Telefone,
                    Email = vendaAtual.Email,
                    Data = vendaAtual.Date,
                    IdVenda = vendaAtual.IdVenda,
                    StatusVenda = vendaAtual.StatusVenda
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
        public IActionResult Create(VendaInputModel vendaInputModel)
        {
            try
            {
                _vendaService.Create(vendaInputModel);

                return Ok("Aguardando Pagamento");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] VendaUpdateInputModel vendaUpdateInputModel)
        {
            try
            {
                _vendaService.Update(id, vendaUpdateInputModel);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }
    }
}
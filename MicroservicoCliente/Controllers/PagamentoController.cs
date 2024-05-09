using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicoCliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PagamentoController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PagamentoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        [Route("pagar")]
        public async Task<IActionResult> Pagar()
        {

            var httpClient = _httpClientFactory.CreateClient();
            // Chamar Microserviço 2
            HttpResponseMessage response = await httpClient.PostAsync("http://microservico-servidor/Notificacao/notificar", null);

            if (response.IsSuccessStatusCode)
            {
                return Ok("Pagamento efetuado com sucesso.");
            }
            else
            {
                return StatusCode((int)response.StatusCode, "Falha ao processar o pagamento.");
            }
        }
    }
}

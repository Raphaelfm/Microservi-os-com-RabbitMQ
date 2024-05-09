using System;
using System.Text;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace MicroservicoServidor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificacaoController : ControllerBase
    {
        [HttpPost]
        [Route("notificar")]
        public IActionResult Notificar()
        {
            EnviarMensagemRabbitMQ();
            return Ok("Notificação enviada com sucesso.");
        }

        private void EnviarMensagemRabbitMQ()
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq", UserName = "guest", Password = "guest" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "notificacoes",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string mensagem = "Nova notificação: " + DateTime.Now;
                var body = Encoding.UTF8.GetBytes(mensagem);

                channel.BasicPublish(exchange: "",
                                     routingKey: "notificacoes",
                                     basicProperties: null,
                                     body: body);
            }
        }
    }
}

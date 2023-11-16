using System.Text;
using System.Text.Json;
using GestaoProdutos.Dominio.Util.Mensageria;
using RabbitMQ.Client;

namespace GestaoProdutos.Infra.Util.Mensageria
{
    public class MensageriaServico : IMensageriaServico
    {
        private readonly ConnectionFactory connectionFactory;

        public MensageriaServico()
        {
            connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }

        public byte[] SerializarMensagem<T>(T mensagem)
        {
            string json = JsonSerializer.Serialize(mensagem);
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            return bytes;
        }

        public void Publish(string queue, byte[] mensagem)
        {
            using (var connection = connectionFactory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue,
                    durable:false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: mensagem
                    );
                }
            }
        }
    }
}
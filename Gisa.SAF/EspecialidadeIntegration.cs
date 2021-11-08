using Gisa.Domain;
using Gisa.Domain.Interfaces.Integration;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gisa.SAF
{
    public class EspecialidadeIntegration : IEspecialidadeIntegration
    {
        private readonly IConfiguration _configuration;
        private readonly string serviceBusConnectionString;
        readonly string _queueName = "especialidade";

        public EspecialidadeIntegration(IConfiguration configuration)
        {
            this._configuration = configuration;
            serviceBusConnectionString = _configuration.GetConnectionString("AzureBusConnectionString");
        }

        public async Task IncluirEspecialidade(Especialidade especialidade)
        {
            var client = new QueueClient(serviceBusConnectionString, _queueName, ReceiveMode.PeekLock);
            string messageBody = JsonSerializer.Serialize(especialidade);
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            await client.SendAsync(message);
            await client.CloseAsync();
        }
    }
}

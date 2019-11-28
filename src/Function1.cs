using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Primitives;
using System.Text;

namespace AppServiceServiceBusManagedIdentity
{
    public static class Function1
    {
        private static string ServiceBusNamespaceUrl = Environment.GetEnvironmentVariable("ServiceBusNamespaceUrl");
        private static string ServiceBusQueueName = Environment.GetEnvironmentVariable("ServiceBusQueueName");

        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var managedIdentityTokenProvider = TokenProvider.CreateManagedIdentityTokenProvider();
            var queueClient = new QueueClient(new Uri(ServiceBusNamespaceUrl).ToString(), ServiceBusQueueName, managedIdentityTokenProvider);
            var message = new Message(Encoding.UTF8.GetBytes("My Message"));
            await queueClient.SendAsync(message);
            return new OkResult();
        }
    }
}

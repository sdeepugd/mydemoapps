using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Microsoft
{
    public static class VoiceMailNotifications
    {
        [FunctionName("VoiceMailNotifications")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest request,
            ILogger log)
        {

            var headers = request.Headers;
            log.LogInformation("Logging headers ------------------");
            foreach(var keypair in headers)
            {
                log.LogInformation(keypair.Key+" : "+keypair.Value);
            }
            log.LogInformation("Logging headers ---------ended---------");

            string name = request.Query["name"];
            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            log.LogInformation(requestBody);
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            string validationToeken = request.Query["validationToken"];

            return new OkObjectResult(validationToeken);
        }
    }
}

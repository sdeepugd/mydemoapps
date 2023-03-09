using System;
using System.Text.Json;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Microsoft
{
    public class TimeoutQueueTrigger
    {
        [FunctionName("TimeoutQueueTrigger")]
        public void Run([QueueTrigger("syncstateq", Connection = "syncstatestorageaccount_STORAGE")]string myQueueItem, ILogger log)
        {
            try{
                DeviceTimoutDetails deviceTimoutDetails = JsonSerializer.Deserialize<DeviceTimoutDetails>(myQueueItem);
                log.LogInformation($"logging device details :{deviceTimoutDetails}");
            }
            catch(Exception e)
            {
                log.LogError(e,"exception while deserialisation");
            }

        }
    }

    public class DeviceTimoutDetails
    {
        public string deviceId;
        public int executionDelayInSeconds;
    }
}

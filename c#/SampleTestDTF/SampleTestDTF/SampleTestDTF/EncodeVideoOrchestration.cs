using DurableTask.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestDTF
{
    public class EncodeVideoOrchestration : TaskOrchestration<string, string>
    {
        //public override async Task<string> RunTask(OrchestrationContext context,string input)
        //{

        //    Console.WriteLine($"in orchestration : {input}");
        //    CancellationTokenSource cancellationTokenForTimer = new CancellationTokenSource();
        //    int count = int.Parse( input );
        //    if (count < 8 )
        //    {
        //        Task timer = context.CreateTimer(context.CurrentUtcDateTime.Add(TimeSpan.FromSeconds(360)), "timer1", cancellationTokenForTimer.Token);
        //        Console.WriteLine($"awaiting timer {input}");
        //        await timer;
        //        if (timer.IsCompleted)
        //        {
        //            Console.WriteLine("timer hits");
        //        }
        //    }
        //    string data = await context.ScheduleTask<string>(typeof(DownloadActivity), input);
        //    return "";
        //}

        public override async Task<string> RunTask(OrchestrationContext context, string input)
        {

            Console.WriteLine($"in orchestration : {input}");
            CancellationTokenSource cancellationTokenForTimer = new CancellationTokenSource();
            Task timer = context.CreateTimer(context.CurrentUtcDateTime.Add(TimeSpan.FromSeconds(360)), "timer1", cancellationTokenForTimer.Token);
            Console.WriteLine($"awaiting timer {input}");
            Console.WriteLine($"starting download activity timer {input}");
            string data = await context.ScheduleTask<string>(typeof(DownloadActivity), input);
            await timer;
            if (timer.IsCompleted)
            {
                Console.WriteLine($"timer hits for {input}");
            }
            return "";
        }
    }
}
using DurableTask.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestDTF
{
    public class EncodeActivity : TaskActivity<string, string>
    {
        protected override string Execute(TaskContext context, string input)
        {
            Console.WriteLine("Encoding video " + input + " started.");
            
            int seconds = 60;
            System.Threading.Thread.Sleep(seconds*1000);

            Console.WriteLine("Encoding video " + input + " complete.");

            return "http://<azurebloblocation>/encoded_video.avi";
        }
    }
}

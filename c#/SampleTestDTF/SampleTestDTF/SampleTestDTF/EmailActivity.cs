using DurableTask.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleTestDTF
{
    public class EmailActivity : TaskActivity<string, object>
    {
        protected override object Execute(TaskContext context, string input)
        {
            Console.WriteLine("Sending Email: " + input + " started.");

            // actually send email to user.
            Random rnd = new Random();
            int seconds = rnd.Next(1, 2);
            System.Threading.Thread.Sleep(seconds);

            Console.WriteLine("Sending Email: " + input + " complete.");

            return null;
        }
    }
}

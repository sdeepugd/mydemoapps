// See https://aka.ms/new-console-template for more information

namespace AzureDTFDemo
{
    internal class Event
    {
        public Event()
        {
        }

        public string EventId { get; set; }
        public string StartTime { get; set; }

        public override string ToString()
        {
            return this.EventId + ":" + this.StartTime;
        }
    }
}
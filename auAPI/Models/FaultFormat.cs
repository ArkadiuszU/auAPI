using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace auAPI.Models
{
    public class Fault
    {
        public DateTime DataTime { get; set; }
        public string Type { get; set; }
        public string Header { get; set; }
        public string Message { get; set; }

        public Fault(string type, string header, string message)
        {
            this.DataTime = DateTime.Now;
            this.Type = type;
            this.Header = header;
            this.Message = message;
        }
    }
}
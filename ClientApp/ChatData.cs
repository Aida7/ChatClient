using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class ChatData
    {
        [JsonProperty("sender")]
        public string Sender { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("time")]
        public DateTime Time { get; set; }
        public ChatData()
        {
            Sender="Name1";
        }
    }
    
}

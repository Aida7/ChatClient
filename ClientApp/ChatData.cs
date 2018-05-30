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
        public DateTime SendDate { get; set; }
        [JsonProperty("file")]
        public byte[] File { get; set; }
        public string FilePath { get; set; }
    }
    
}

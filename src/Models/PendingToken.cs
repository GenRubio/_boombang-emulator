using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Models
{
    internal class PendingToken
    {
        public string Token { get; set; }
        public WebSocket WebSocket { get; set; }
        public DateTime TimeOut { get; set; }
        public PendingToken(string token, WebSocket webSocket)
        {
            this.Token = token;
            this.WebSocket = webSocket;
            this.TimeOut = DateTime.Now.AddMinutes(1);
        }
    }
}

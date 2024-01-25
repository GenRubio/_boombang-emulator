using System.Text.RegularExpressions;

namespace boombang_emulator.src.Models.Messages
{
    internal class ClientMessage
    {
        private string Data { get; set; }
        private List<int> Headers { get; set; }
        public string[,] Parameters { get; set; }
        public ClientMessage(string data)
        {
            Data = data;
            Headers = [];

            foreach (string header in Regex.Split(Regex.Split(data.Substring(1), "³²")[0], "³"))
            {
                if (header.Length == 1)
                {
                    Headers.Add(Convert.ToInt32(Convert.ToChar(header)));
                }
                else
                {
                    Headers.Add(0);
                }
            }

            int subParametersLength = 0;

            for (int i = 1; i < data.Split('²').Length; i++)
            {
                for (int j = 0; j < data.Split('²')[i].Split('³').Length - 1; j++)
                {
                    if (data.Split('²')[i].Split('³').Length > subParametersLength)
                    {
                        subParametersLength = data.Split('²')[i].Split('³').Length;
                    }
                }
            }

            Parameters = new string[data.Split('²').Length, subParametersLength];

            for (int i = 1; i < data.Split('²').Length; i++)
            {
                for (int j = 0; j < data.Split('²')[i].Split('³').Length - 1; j++)
                {
                    Parameters[i - 1, j] = data.Split('²')[i].Split('³')[j];
                }
            }

        }
        public string GetData()
        {
            return Data;
        }
        public string GetHandler()
        {
            string Handler = "Method";
            foreach (int ActualHeader in Headers)
            {
                Handler += "_" + ActualHeader;
            }
            return Handler;
        }
        public int GetInteger()
        {
            string num = "";
            foreach (int ActualHeader in Headers)
            {
                num += ActualHeader;
            }
            return Convert.ToInt32(num);
        }
        public int GetHeader()
        {
            return GetInteger();
        }
        public new string ToString()
        {
            return "Packet Information: " + GetHandler() + " -> " + GetData();
        }
    }
}

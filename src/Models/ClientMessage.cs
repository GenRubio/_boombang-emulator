using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace boombang_emulator.src.Models
{
    internal class ClientMessage
    {
        private string data;
        private List<int> headers;
        public string[,] parameters;
        public ClientMessage(string data)
        {
            this.data = data;
            this.headers = new List<int>();

            foreach (string header in Regex.Split(Regex.Split(data.Substring(1), "³²")[0], "³"))
            {
                if (header.Length == 1)
                {
                    this.headers.Add(Convert.ToInt32(Convert.ToChar(header)));
                }
                else
                {
                    this.headers.Add(0);
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

            this.parameters = new string[data.Split('²').Length, subParametersLength];

            for (int i = 1; i < data.Split('²').Length; i++)
            {
                for (int j = 0; j < data.Split('²')[i].Split('³').Length - 1; j++)
                {
                    this.parameters[i - 1, j] = data.Split('²')[i].Split('³')[j];
                }
            }

        }

        public string GetData()
        {
            return this.data;
        }

        public string GetHandler()
        {
            string Handler = "Method";
            foreach (int ActualHeader in this.headers)
            {
                Handler += "_" + ActualHeader;
            }
            return Handler;
        }
        public int GetInteger()
        {
            string num = "";
            foreach (int ActualHeader in this.headers)
            {
                num += ActualHeader;
            }
            return Convert.ToInt32(num);
        }
        public new string ToString()
        {
            return "Packet Information: " + this.GetHandler() + " -> " + this.GetData();
        }
    }
}

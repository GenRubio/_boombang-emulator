using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Models
{
    internal class ServerMessage
    {
        private List<byte> Header = new List<byte>();
        private List<object[]> Parameters = new List<object[]>();
        private Encoding Encoding;
        public ServerMessage(byte[] Header, params object[] Parameters)
        {
            this.Encoding = Encoding.GetEncoding("iso-8859-1");
            foreach (byte ActualByte in Header)
            {
                this.Header.Add(ActualByte);
            }

            foreach (object Parameter in Parameters)
            {
                this.Parameters.Add(new object[] { Parameter });
            }
        }
        public void AppendParameter(object Parameter)
        {
            this.Parameters.Add(new object[] { Parameter });
        }
        public void AppendParameter(object[] ParameterGroup)
        {
            this.Parameters.Add(ParameterGroup);
        }
        public byte[] GetContent()
        {
            List<byte> Message = new List<byte>();
            Message.Add(0xb1);
            foreach (byte ActualHeader in Header)
            {
                Message.Add(ActualHeader);
                Message.Add(0xb3);
            }
            Message.Add(0xb2);
            foreach (object[] ParameterGroup in Parameters)
            {
                if (ParameterGroup != null)
                {
                    foreach (object Parameter in ParameterGroup)
                    {
                        if (Parameter != null && Convert.ToString(Parameter) != "")
                        {
                            foreach (byte ParameterByte in this.Encoding.GetBytes(Parameter.ToString()))
                            {
                                Message.Add(ParameterByte);
                            }
                        }
                        Message.Add(0xb3);
                    }
                }
                else
                {
                    Message.Add(0xb3);
                }
                Message.Add(0xb2);
            }
            Message.Add(0xb0);
            return Message.ToArray();
        }

        public new string ToString()
        {
            List<byte> Message = new List<byte>();
            Message.Add(0xb1);
            foreach (byte ActualHeader in Header)
            {
                Message.Add(ActualHeader);
                Message.Add(0xb3);
            }
            Message.Add(0xb2);
            foreach (object[] ParameterGroup in Parameters)
            {
                if (ParameterGroup != null)
                {
                    foreach (object Parameter in ParameterGroup)
                    {
                        if (Parameter != null)
                        {
                            foreach (byte ParameterByte in this.Encoding.GetBytes(Parameter.ToString()))
                            {
                                Message.Add(ParameterByte);
                            }
                        }
                        Message.Add(0xb3);
                    }
                }
                else
                {
                    Message.Add(0xb3);
                }
                Message.Add(0xb2);
            }
            Message.Add(0xb0);
            return this.Encoding.GetString(Message.ToArray());
        }
    }
}

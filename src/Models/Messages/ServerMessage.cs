using System.Text;

namespace boombang_emulator.src.Models.Messages
{
    internal class ServerMessage
    {
        private List<byte> Header = [];
        private List<object[]> Parameters = [];
        private readonly Encoding Encoding;
        public ServerMessage(byte[] Header, params object[] Parameters)
        {
            Encoding = Encoding.GetEncoding("iso-8859-1");
            foreach (byte ActualByte in Header)
            {
                this.Header.Add(ActualByte);
            }

            foreach (object Parameter in Parameters)
            {
                this.Parameters.Add([Parameter]);
            }
        }
        public void AppendParameter(object Parameter)
        {
            Parameters.Add([Parameter]);
        }
        public void AppendParameter(object[] ParameterGroup)
        {
            Parameters.Add(ParameterGroup);
        }
        public byte[] GetContent()
        {
            List<byte> Message = [];
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
                            foreach (byte ParameterByte in Encoding.GetBytes(Parameter.ToString()))
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
            return [.. Message];
        }

        public new string ToString()
        {
            List<byte> Message = [];
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
                            foreach (byte ParameterByte in Encoding.GetBytes(Parameter.ToString()))
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
            return Encoding.GetString(Message.ToArray());
        }
    }
}

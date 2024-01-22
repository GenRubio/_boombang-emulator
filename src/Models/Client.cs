using boombang_emulator.src.Controllers;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;
using boombang_emulator.src.Utils;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;

namespace boombang_emulator.src.Models
{
    internal class Client
    {
        public string Uid { get; set; }
        private Socket Socket { get; set; }
        private byte[] Buffer { get; set; }
        private Encoding Encoding { get; set; }
        private int EncipherConstant { get; set; }
        private int EncipherMorph { get; set; }
        private int DecipherConstant { get; set; }
        private int DecipherMorph { get; set; }
        public string? JwtToken { get; set; }
        public User? User { get; set; }
        public WebSocket WebSocket { get; set; }
        public bool IsInGame { get; set; }
        public Client(Socket socket)
        {
            this.Uid = socket.RemoteEndPoint!.ToString()!;
            this.Socket = socket;
            this.Buffer = new byte[2048];
            this.Encoding = Encoding.GetEncoding("iso-8859-1");
            this.EncipherConstant = 135;
            this.DecipherConstant = 135;
            this.Socket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
            this.IsInGame = false;
        }
        private void OnReceive(IAsyncResult iAr)
        {
            try
            {
                int length = this.Socket.EndReceive(iAr);
                if (length > 0)
                {
                    if (this.Socket == null)
                    {
                        return;
                    }
                    int Length = this.Socket.EndReceive(iAr);
                    if (Length == 0 || Length > this.Buffer.Length)
                    {
                        this.Close();
                        return;
                    }
                    char[] Chars = new char[Length];
                    this.Encoding.GetChars(Buffer, 0, Length, Chars, 0);
                    string data = new(Chars);

                    if (!Policy(data))
                    {
                        data = this.Encoding.GetString(Decrypt(this.Encoding.GetBytes(data)));
                        ProcessData(data);
                    }

                    this.Socket.BeginReceive(this.Buffer, 0, this.Buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
                }
                else
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                this.Close();
            }
        }

        private void ProcessData(string data)
        {
            try
            {
                if (this.Socket == null || !this.Socket.Connected)
                {
                    return;
                }
                if (data[0] != Convert.ToChar(177))
                {
                    this.Close();
                }
                string[] datas = data.Split(Convert.ToChar(177));
                for (int i = 1; i < datas.Length; i++)
                {
                    ClientMessage clientMessage = new(Convert.ToChar(177) + datas[i]);
                    HandlerController.SendHandler(this, clientMessage);
                }
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                this.Close();
            }
        }
        private bool Policy(string data)
        {
            if (data.Contains("<policy-file-request/>"))
            {
                this.Socket.Send(this.Encoding.GetBytes("<?xml version=\"1.0\"?>\r\n<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\r\n<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"" + Config.port + "\" />\r\n</cross-domain-policy>\0"));
                return true;
            }
            return false;
        }
        public byte[] Decrypt(byte[] Data)
        {
            int Length = Data.Length;
            int ActualByte;
            int Morph;
            byte[] Buffer = new byte[Length];
            int Index = 0;
            while (Length-- > 0)
            {
                ActualByte = Data[Index];
                Morph = (ActualByte ^ this.DecipherConstant) ^ this.DecipherMorph;
                Buffer[Index] = (byte)Morph;
                Index++;
                this.DecipherConstant = (1103515245 * this.DecipherConstant) + 12344;
                this.DecipherMorph = Morph;
            }
            return Buffer;
        }
        public byte[] Encrypt(byte[] Data)
        {
            int Length = Data.Length;
            int ActualByte;
            int Morph;
            byte[] Buffer = new byte[Length];
            int Index = 0;
            while (Length-- > 0)
            {
                ActualByte = Data[Index];
                Morph = (ActualByte ^ this.EncipherConstant) ^ this.EncipherMorph;
                Buffer[Index] = (byte)Morph;
                Index++;
                this.EncipherConstant = (1103515245 * this.EncipherConstant) + 12344;
                this.EncipherMorph = ActualByte;
            }
            return Buffer;
        }
        public void Close()
        {
            if (this.Socket != null && this.Socket.Connected)
            {
                this.Socket.Close();
            }
            if (this.User != null && this.User.Scenery != null)
            {
                int userKeyInArea = this.User.Scenery.GetClientIdentifier(this.User.Id);
                this.User.Scenery.SendData(new([128, 123], [userKeyInArea]));

                this.User.Scenery.RemoveClient(this);
            }
            if (this.WebSocket != null && this.WebSocket.State == WebSocketState.Open)
            {
                RenderAreasPacketWeb.Invoke(this);
                RenderAreasCountUserPacketWeb.Invoke(null);
                this.WebSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
            }
            SocketGameController.clients.TryRemove(this.Uid, out _);
        }
        public Socket GetSocket()
        {
            return this.Socket;
        }
        public void SendData(ServerMessage serverMessage)
        {
            if (this.Socket != null && this.Socket.Connected)
            {
                this.Socket.Send(Encrypt(serverMessage.GetContent()));
            }
        }
    }
}

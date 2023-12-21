using boombang_emulator.src.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace boombang_emulator.src.Models
{
    internal class Client
    {
        private Socket socket;
        private byte[] buffer;
        private Encoding encoding;
        private int port;
        private int encipherConstant;
        private int encipherMorph;
        private int decipherConstant;
        private int decipherMorph;
        public string? jwtToken;
        public string? websocketToken;
        public string apiRoute;
        public User? user;
        public Client(Socket socket, int port)
        {
            this.socket = socket;
            this.port = port;
            this.buffer = new byte[2048];
            this.encoding = Encoding.GetEncoding("iso-8859-1");
            this.encipherConstant = 135;
            this.decipherConstant = 135;
            this.apiRoute = "http://localhost:8000/api";
            this.socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
        }

        private void OnReceive(IAsyncResult iAr)
        {
            try
            {
                int length = this.socket.EndReceive(iAr);
                if (length > 0)
                {
                    if (this.socket == null)
                    {
                        return;
                    }
                    int Length = this.socket.EndReceive(iAr);
                    if (Length == 0 || Length > this.buffer.Length)
                    {
                        this.socket.Close();
                        return;
                    }
                    char[] Chars = new char[Length];
                    this.encoding.GetChars(buffer, 0, Length, Chars, 0);
                    string data = new string(Chars);

                    if (!Policy(data))
                    {
                        data = this.encoding.GetString(Decrypt(this.encoding.GetBytes(data)));
                        ProcessData(data);
                    }

                    this.socket.BeginReceive(this.buffer, 0, this.buffer.Length, SocketFlags.None, new AsyncCallback(this.OnReceive), null);
                }
                else
                {
                    this.socket.Close();
                }
            }
            catch (Exception)
            {
                if (this.socket != null)
                {
                    this.socket.Close();
                }
            }
        }

        private void ProcessData(string data)
        {
            try
            {
                if (this.socket == null || !this.socket.Connected) { 
                    return; 
                }
                if (data[0] != Convert.ToChar(177))
                {
                    this.socket.Close();
                }
                string[] datas = data.Split(Convert.ToChar(177));
                for (int i = 1; i < datas.Length; i++)
                {
                    ClientMessage clientMessage = new ClientMessage(Convert.ToChar(177) + datas[i]);
                    HandlerController.SendHandler(this, clientMessage);
                }
            }
            catch {
                this.socket.Close();
            }
        }
        private bool Policy(string data)
        {
            if (data.Contains("<policy-file-request/>"))
            {
                this.socket.Send(this.encoding.GetBytes("<?xml version=\"1.0\"?>\r\n<!DOCTYPE cross-domain-policy SYSTEM \"/xml/dtds/cross-domain-policy.dtd\">\r\n<cross-domain-policy>\r\n<allow-access-from domain=\"*\" to-ports=\"" + this.port + "\" />\r\n</cross-domain-policy>\0"));
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
                Morph = (ActualByte ^ this.decipherConstant) ^ this.decipherMorph;
                Buffer[Index] = (byte)Morph;
                Index++;
                this.decipherConstant = (1103515245 * this.decipherConstant) + 12344;
                this.decipherMorph = Morph;
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
                Morph = (ActualByte ^ this.encipherConstant) ^ this.encipherMorph;
                Buffer[Index] = (byte)Morph;
                Index++;
                this.encipherConstant = (1103515245 * this.encipherConstant) + 12344;
                this.encipherMorph = ActualByte;
            }
            return Buffer;
        }
        public void Close()
        {
            if (this.socket != null && this.socket.Connected)
            {
                this.socket.Close();
            }
        }
        public Socket GetSocket()
        {
            return this.socket;
        }
        public void SendData(ServerMessage serverMessage)
        {
            if (this.socket != null && this.socket.Connected)
            {
                this.socket.Send(Encrypt(serverMessage.GetContent()));
            }   
        }
    }
}

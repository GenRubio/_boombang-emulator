using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using boombang_emulator.src.Models;

namespace boombang_emulator.src.Controllers
{
    internal class SocketGameController
    {
        private static int port = 2001;
        private static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static List<Client> clients = new List<Client>();

        public static void Invoke()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port));
            socket.Listen(100);

            Listen();
        }
        private static void Listen()
        {
            Console.WriteLine("Esperando conexiones...");
            socket.BeginAccept(new AsyncCallback(OnAccept), null);
        }
        private static void OnAccept(IAsyncResult iAr)
        {
            try
            {
                Socket session = socket.EndAccept(iAr);
                Console.WriteLine("Conexión aceptada.");

                if (session != null && session.RemoteEndPoint != null)
                {
                    string? sessionEndPoint = session.RemoteEndPoint.ToString();
                    Console.WriteLine("Conexión aceptada desde: " + sessionEndPoint);

                    Client? errorClient = clients.Find(c => {
                        try
                        {
                            return c.GetSocket().RemoteEndPoint.ToString() == sessionEndPoint;
                        }
                        catch (Exception)
                        {
                            return true;
                        }
                    });

                    if (errorClient != null)
                    {
                        clients.Remove(errorClient);
                    }
                    clients.Add(new Client(session, port));
                    Listen();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;

namespace boombang_emulator.src.Controllers
{
    internal class SocketGameController
    {
        private static Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static ConcurrentDictionary<string, Models.Client> clients = [];

        public static void Invoke()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, Config.port));
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
                    if (sessionEndPoint == null)
                    {
                        return;
                    }
                    Console.WriteLine("Conexión aceptada desde: " + sessionEndPoint);

                    clients.TryRemove(sessionEndPoint, out _);
                    clients.TryAdd(sessionEndPoint, new Models.Client(session));

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

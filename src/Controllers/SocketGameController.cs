using System.Net.Sockets;
using System.Net;

namespace boombang_emulator.src.Controllers
{
    internal class SocketGameController
    {
        private static Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        public static List<Models.Client> clients = [];

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
                    Console.WriteLine("Conexión aceptada desde: " + sessionEndPoint);

                    Models.Client? errorClient = clients.Find(c => {
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
                    clients.Add(new Models.Client(session));
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

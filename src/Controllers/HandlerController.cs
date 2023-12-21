using boombang_emulator.src.Handlers;
using boombang_emulator.src.Handlers.Auth;
using boombang_emulator.src.Handlers.Backpack;
using boombang_emulator.src.Handlers.BPad;
using boombang_emulator.src.Handlers.Catalog;
using boombang_emulator.src.Handlers.House;
using boombang_emulator.src.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace boombang_emulator.src.Controllers
{
    delegate void ProcessHandler(Client client, ClientMessage clientMessage);
    internal class HandlerController
    {
        private static ConcurrentDictionary<int, ProcessHandler> handlers = new ConcurrentDictionary<int, ProcessHandler>();
        public static void Invoke()
        {
            InvokeHandlers();
        }
        private static void InvokeHandlers()
        {
            PingHandler.Invoke();
            LoginHandler.Invoke();
            BPadFriendsHandler.Invoke();
            BPadMessagesHandler.Invoke();
            CatalogHandler.Invoke();
            BackpackUserHandler.Invoke();
            UserHouseButtonHandler.Invoke();
            UndefinedHandlers.Invoke();
        }
        public static void SetHandler(int header, ProcessHandler handler)
        {
            handlers.TryAdd(header, handler);
        }
        public static void SendHandler(Client client, ClientMessage clientMessage)
        {
            if (client.GetSocket().Connected && clientMessage != null)
            {

                if (!handlers.ContainsKey(clientMessage.GetInteger()))
                {
                    //if (Session.User != null)
                    //    Output.WriteLine("[" + Session.User.name + "] Falta: " + Message.GetInteger() + " -> " + Message.GetData(), Type.medio);
                    //else
                    //    Output.WriteLine("Falta: " + Message.GetInteger() + " -> " + Message.GetData(), Type.medio);
                    Console.WriteLine("Falta: " + clientMessage.GetInteger() + " -> " + clientMessage.GetData());
                }
                else
                {
                    try
                    {
                        handlers[clientMessage.GetInteger()](client, clientMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        //Session.FinalizarConexión();
                    }
                    //catch (Exception ex)
                    //{
                    //    //if (Session.User == null)
                    //    //{
                    //    //    Output.WriteLine(Session.IP + " ] ha causado un error: " + ex.ToString(), Type.alto);
                    //    //    Session.FinalizarConexión();
                    //    //}
                    //    //else
                    //    //{
                    //    //    Output.WriteLine(Session.User.name + " ] ha causado un error: " + ex.ToString(), Type.alto);
                    //    //    Session.FinalizarConexión();
                    //    //}
                    //}
                }
            }
        }
    }
}

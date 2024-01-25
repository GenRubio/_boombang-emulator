using boombang_emulator.src.Controllers;
using boombang_emulator.src.Handlers.Scenery.Packets;
using boombang_emulator.src.Models;
using boombang_emulator.src.Models.Messages;
using boombang_emulator.src.Utils;

namespace boombang_emulator.src.Handlers.Scenery
{
    internal class ChatHandler
    {
        public static void Invoke()
        {
            HandlerController.SetHandler(186, new ProcessHandler(Handler));
        }
        private static void Handler(Client client, ClientMessage clientMessage)
        {
            try
            {
                Middlewares.IsUserInScenery(client);

                bool isBlockedAction = client.User!.Actions.Action.Chat;
                if (isBlockedAction)
                {
                    return;
                }

                ParameterValidator validator = new();
                validator.ValidateParameter<string>((object)clientMessage.Parameters[1, 0]);

                string message = clientMessage.Parameters[1, 0];

                if (message.StartsWith("/"))
                {
                    Command(client, message);
                    return;
                }

                PublicChatPacket.Invoke(client, message);

                client.User!.Actions.GenericAction.SetAction(Enums.AvatarActionsEnum.CHAT, client);
            }
            catch (Exception ex)
            {
                ConsoleUtils.WriteError(ex);
                client.Close();
            }
        }
        private static void Command(Client client, string text)
        {
            string[] data = text.Split(' ');
            switch (data[0].ToLower())
            {
                case "/avatar":
                    {
                        var parameter = data[1];
                        ServerMessage serverMessage = new([125, 120]);
                        serverMessage.AppendParameter(client.User!.Id);
                        serverMessage.AppendParameter(parameter);
                        serverMessage.AppendParameter(client.User!.Avatar.Color);
                        serverMessage.AppendParameter(1);
                        client.User.Scenery!.SendData(serverMessage);
                        break;
                    }
                case "/expression":
                    {
                        // /expression 1 1000
                        for (int i = 0; i < 2; i++)
                        {
                            var parameter1 = data[1];
                            var parameter2 = data[2];
                            ServerMessage serverMessage = new([134]);
                            serverMessage.AppendParameter(parameter1);
                            serverMessage.AppendParameter(client.User!.Id);
                            client.User!.Scenery!.SendData(serverMessage);
                            Thread.Sleep(Convert.ToInt32(parameter2));
                        }
                        break;
                    }
                case "/romantic":
                    {
                        // /expression 1 1000
                        for (int i = 0; i < 2; i++)
                        {
                            var parameter1 = data[1];
                            var parameter2 = data[2];
                            Models.Scenarios.Scenery scenery = client.User!.Scenery!;
                            int userKeyInArea = scenery.GetClientIdentifier(client.User.Id);

                            ServerMessage serverMessage = new([137, 122]);
                            serverMessage.AppendParameter(parameter1);
                            serverMessage.AppendParameter(userKeyInArea);
                            serverMessage.AppendParameter(client.User!.ActualPositionInScenery!.X);
                            serverMessage.AppendParameter(client.User!.ActualPositionInScenery!.Y);
                            serverMessage.AppendParameter(userKeyInArea);
                            serverMessage.AppendParameter(client.User!.ActualPositionInScenery!.X);
                            serverMessage.AppendParameter(client.User!.ActualPositionInScenery!.Y);
                            client.User!.Scenery!.SendData(serverMessage);
                            Thread.Sleep(Convert.ToInt32(parameter2));
                        }
                        break;
                    }
            }
        }
    }
}

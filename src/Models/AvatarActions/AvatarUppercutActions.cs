using boombang_emulator.src.Enums;
using boombang_emulator.src.HandlersWeb.FlowerPower.Packets;

namespace boombang_emulator.src.Models.AvatarActions
{
    internal class AvatarUppercutActions
    {
        private User User { get; set; }
        public AvatarActions Actions { get; set; }
        public AvatarUppercutActions(AvatarActions avatarActions, User user)
        {
            Actions = avatarActions;
            User = user;
        }
        public void SetAction(AvatarActionsEnum action, Client client, bool removeUser = false)
        {
            DateTime timeEnd = DateTime.Now;
            Actions.ResetActionsSource = new();
            CancellationToken resetToken = Actions.ResetActionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.GIVE_UPPERCUT:
                case AvatarActionsEnum.RECEIVE_UPPERCUT:
                    Actions.SetBlockRomanticInteractions(true);
                    Actions.ResetExpressionsSource?.Cancel();
                    Actions.SetBlockExpressions(true);
                    Actions.SetBlockCoconuts(true);
                    Actions.SetBlockUppercut(true);
                    break;
            }
            timeEnd = Actions.GetTime(action);
            Task.Run(() => StartTimer(timeEnd, action, client, removeUser, resetToken));
        }
        private async Task StartTimer(
            DateTime timeEnd,
            AvatarActionsEnum action,
            Client client,
            bool removeUser,
            CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    if (timeEnd < DateTime.Now)
                    {
                        switch (action)
                        {
                            case AvatarActionsEnum.GIVE_UPPERCUT:
                                {
                                    Actions.SetBlockRomanticInteractions(false);
                                    Actions.SetBlockExpressions(false);
                                    Actions.SetBlockCoconuts(false);
                                    Actions.SetBlockUppercut(false);
                                }
                                break;
                            case AvatarActionsEnum.RECEIVE_UPPERCUT:
                                {
                                    if (removeUser)
                                    {
                                        RemoveUserFromScenery(client);
                                    }
                                    Actions.SetBlockRomanticInteractions(false);
                                    Actions.SetBlockExpressions(false);
                                    Actions.SetBlockCoconuts(false);
                                    Actions.SetBlockUppercut(false);
                                }
                                break;
                        }
                        break;
                    }
                    await Task.Delay(100, cancellationToken);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception)
                {
                    break;
                }
            }
        }
        public bool IsPermitted()
        {
            return !(Actions.GiveUppercut || Actions.ReceiveCoconut);
        }
        private static void RemoveUserFromScenery(Client client)
        {
            client.User!.Scenery!.RemoveClient(client);

            client.SendData(new([153]));

            RenderAreasPacketWeb.Invoke(client);
            RenderAreasCountUserPacketWeb.Invoke(null);
        }
    }
}

using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Models.AvatarActions
{
    internal class AvatarGenericActions
    {
        public AvatarActions Actions { get; set; }
        public AvatarGenericActions(AvatarActions avatarActions)
        {
            Actions = avatarActions;
        }
        public void SetAction(AvatarActionsEnum action, Client client)
        {
            DateTime timeEnd = DateTime.Now;
            bool startTimer = true;
            Actions.ResetActionsSource = new();
            CancellationToken resetToken = Actions.ResetActionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.WALK:
                    startTimer = false;
                    Actions.ResetExpressionsSource?.Cancel();
                    Actions.SetBlockExpressions(false);
                    break;
                case AvatarActionsEnum.WATCH:
                    Actions.Watch = true;
                    break;
                case AvatarActionsEnum.CHAT:
                    Actions.Chat = true;
                    break;
            }
            timeEnd = Actions.GetTime(client.User!.Avatar.Id, action);
            if (startTimer)
            {
                Task.Run(() => StartTimer(timeEnd, action, resetToken));
            }
        }
        private async Task StartTimer(DateTime timeEnd, AvatarActionsEnum action, CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    if (timeEnd < DateTime.Now)
                    {
                        switch (action)
                        {
                            case AvatarActionsEnum.WALK:
                                break;
                            case AvatarActionsEnum.WATCH:
                                Actions.Watch = false;
                                break;
                            case AvatarActionsEnum.CHAT:
                                Actions.Chat = false;
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
    }
}

using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Models.AvatarActions
{
    internal class AvatarRomanticInteractionActions
    {
        public AvatarActions Actions { get; set; }
        public AvatarRomanticInteractionActions(AvatarActions avatarActions)
        {
            Actions = avatarActions;
        }
        public void SetAction(AvatarActionsEnum action)
        {
            DateTime timeEnd = DateTime.Now;
            Actions.ResetActionsSource = new();
            CancellationToken resetToken = Actions.ResetActionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.GIVE_KISS:
                case AvatarActionsEnum.GIVE_DRINK:
                case AvatarActionsEnum.GIVE_ROSE:
                case AvatarActionsEnum.RECEIVE_KISS:
                case AvatarActionsEnum.RECEIVE_DRINK:
                case AvatarActionsEnum.RECEIVE_ROSE:
                    Actions.SetBlockRomanticInteractions(true);
                    Actions.ResetExpressionsSource?.Cancel();
                    Actions.SetBlockExpressions(true);
                    Actions.SetBlockCoconuts(true);
                    break;
            }
            timeEnd = Actions.GetTime(action);
            Task.Run(() => StartTimer(timeEnd, action, resetToken));
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
                            case AvatarActionsEnum.GIVE_KISS:
                            case AvatarActionsEnum.GIVE_DRINK:
                            case AvatarActionsEnum.GIVE_ROSE:
                            case AvatarActionsEnum.RECEIVE_KISS:
                            case AvatarActionsEnum.RECEIVE_DRINK:
                            case AvatarActionsEnum.RECEIVE_ROSE:
                                Actions.SetBlockRomanticInteractions(false);
                                Actions.SetBlockExpressions(false);
                                Actions.SetBlockCoconuts(false);
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
            return !(Actions.GiveKiss || Actions.ReceiveKiss
                || Actions.GiveDrink || Actions.ReceiveDrink
                || Actions.GiveRose || Actions.ReceiveRose);
        }
    }
}

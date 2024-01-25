using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Models.AvatarActions
{
    internal class AvatarExpressionActions
    {
        public AvatarActions Actions { get; set; }
        public AvatarExpressionActions(AvatarActions avatarActions)
        {
            Actions = avatarActions;
        }
        public void SetAction(AvatarActionsEnum action, Client client)
        {
            DateTime timeEnd = DateTime.Now;
            Actions.ResetExpressionsSource = new();
            CancellationToken resetToken = Actions.ResetExpressionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.LITTLE_LAUGHTER:
                case AvatarActionsEnum.BIG_LAUGHTER:
                case AvatarActionsEnum.CRY:
                case AvatarActionsEnum.IN_LOVE:
                case AvatarActionsEnum.SPIT:
                case AvatarActionsEnum.FART:
                case AvatarActionsEnum.SPECIAL:
                case AvatarActionsEnum.FLY:
                    Actions.ResetExpressionsSource = new();
                    resetToken = Actions.ResetExpressionsSource.Token;
                    Actions.SetBlockExpressions(true);
                    break;
            }
            timeEnd = Actions.GetTime(client.User!.Avatar.Id, action);
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
                            case AvatarActionsEnum.LITTLE_LAUGHTER:
                            case AvatarActionsEnum.BIG_LAUGHTER:
                            case AvatarActionsEnum.CRY:
                            case AvatarActionsEnum.IN_LOVE:
                            case AvatarActionsEnum.SPIT:
                            case AvatarActionsEnum.FART:
                            case AvatarActionsEnum.SPECIAL:
                            case AvatarActionsEnum.FLY:
                                Actions.SetBlockExpressions(false);
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
            return !(Actions.LittleLaughter || Actions.BigLaughter
                    || Actions.Cry || Actions.InLove
                    || Actions.Spit || Actions.Fart
                    || Actions.Special || Actions.Fly);
        }
    }
}

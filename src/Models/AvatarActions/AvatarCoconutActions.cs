﻿using boombang_emulator.src.Enums;
using boombang_emulator.src.Handlers.Scenery.Packets;

namespace boombang_emulator.src.Models.AvatarActions
{
    internal class AvatarCoconutActions
    {
        private User User { get; set; }
        public AvatarActions Actions { get; set; }
        public AvatarCoconutActions(AvatarActions avatarActions, User user)
        {
            Actions = avatarActions;
            User = user;
        }
        public void SetAction(AvatarActionsEnum action, int coconutId)
        {
            DateTime timeEnd = DateTime.Now;
            Actions.ResetActionsSource = new();
            CancellationToken resetToken = Actions.ResetActionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.RECEIVE_COCONUT:
                case AvatarActionsEnum.RECEIVE_COCONUT_SNOWBALL:
                case AvatarActionsEnum.RECEIVE_COCONUT_SHOE:
                case AvatarActionsEnum.RECEIVE_COCONUT_CAKE:
                case AvatarActionsEnum.RECEIVE_COCONUT_FLOWERPOT:
                case AvatarActionsEnum.RECEIVE_COCONUT_HONEYCOMB:
                case AvatarActionsEnum.RECEIVE_COCONUT_TRASH:
                case AvatarActionsEnum.RECEIVE_COCONUT_WATERMELON:
                case AvatarActionsEnum.RECEIVE_COCONUT_YUNQUE:
                case AvatarActionsEnum.RECEIVE_COCONUT_PIANO:
                    Actions.SetBlockRomanticInteractions(true);
                    Actions.ResetExpressionsSource?.Cancel();
                    Actions.SetBlockExpressions(true);
                    Actions.SetBlockUppercut(true);
                    Actions.SetBlockCoconuts(true);
                    break;
            }
            timeEnd = Actions.GetTime(action);
            Task.Run(() => StartTimer(timeEnd, action, coconutId, resetToken));
        }
        private async Task StartTimer(DateTime timeEnd,
            AvatarActionsEnum action,
            int coconutId,
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
                            case AvatarActionsEnum.RECEIVE_COCONUT:
                            case AvatarActionsEnum.RECEIVE_COCONUT_SNOWBALL:
                            case AvatarActionsEnum.RECEIVE_COCONUT_SHOE:
                            case AvatarActionsEnum.RECEIVE_COCONUT_CAKE:
                            case AvatarActionsEnum.RECEIVE_COCONUT_FLOWERPOT:
                            case AvatarActionsEnum.RECEIVE_COCONUT_HONEYCOMB:
                            case AvatarActionsEnum.RECEIVE_COCONUT_TRASH:
                            case AvatarActionsEnum.RECEIVE_COCONUT_WATERMELON:
                            case AvatarActionsEnum.RECEIVE_COCONUT_YUNQUE:
                            case AvatarActionsEnum.RECEIVE_COCONUT_PIANO:
                                Actions.SetBlockRomanticInteractions(false);
                                Actions.SetBlockExpressions(false);
                                Actions.SetBlockCoconuts(false);
                                Actions.SetBlockUppercut(false);
                                break;
                        }
                        RemoveCoconutPacket.Invoke(this.User, coconutId);
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
            return !(Actions.ReceiveCoconut || Actions.ReceiveCoconutCake
                || Actions.ReceiveCoconutFlowerpot || Actions.ReceiveCoconutHoneycomb
                || Actions.ReceiveCoconutShoe || Actions.ReceiveCoconutSnowball
                || Actions.ReceiveCoconutTrash || Actions.ReceiveCoconutWatermelon
                || Actions.ReceiveCoconutYunque || Actions.ReceiveCoconutPiano);
        }
    }
}

using boombang_emulator.src.Dictionaries;
using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Models
{
    internal class ActionsEngine
    {
        public bool Walk { get; set; }
        public bool Watch { get; set; }
        public bool Chat { get; set; }
        public bool LittleLaughter { get; set; }
        public bool BigLaughter { get; set; }
        public bool Cry { get; set; }
        public bool InLove { get; set; }
        public bool Spit { get; set; }
        public bool Fart { get; set; }
        public bool Special { get; set; }
        public bool Fly { get; set; }
        public bool GiveKiss { get; set; }
        public bool ReceiveKiss { get; set; }
        public bool GiveDrink { get; set; }
        public bool ReceiveDrink { get; set; }
        public bool GiveRose { get; set; }
        public bool ReceiveRose { get; set; }
        public CancellationTokenSource? ResetActionsSource { get; set; }
        public CancellationTokenSource? ResetExpressionsSource { get; set; }
        public ActionsEngine()
        {
            this.Walk = false;
            this.Watch = false;
            this.Chat = false;
            this.LittleLaughter = false;
            this.BigLaughter = false;
            this.Cry = false;
            this.InLove = false;
            this.Spit = false;
            this.Fart = false;
            this.Special = false;
            this.Fly = false;
            this.GiveKiss = false;
            this.GiveDrink = false;
            this.GiveRose = false;
            this.ReceiveKiss = false;
            this.ReceiveDrink = false;
            this.ReceiveRose = false;
        }
        public void SetAction(AvatarActionsEnum action, int avatarId)
        {
            DateTime timeEnd = DateTime.Now;
            bool startTimer = true;
            this.ResetActionsSource = new();
            CancellationToken resetToken = this.ResetActionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.WALK:
                    startTimer = false;
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(false);
                    break;
                case AvatarActionsEnum.WATCH:
                    this.Watch = true;
                    break;
                case AvatarActionsEnum.CHAT:
                    this.Chat = true;
                    break;
                // Romantic interactions
                case AvatarActionsEnum.GIVE_KISS:
                case AvatarActionsEnum.GIVE_DRINK:
                case AvatarActionsEnum.GIVE_ROSE:
                case AvatarActionsEnum.RECEIVE_KISS:
                case AvatarActionsEnum.RECEIVE_DRINK:
                case AvatarActionsEnum.RECEIVE_ROSE:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    break;
                // User actions
                case AvatarActionsEnum.LITTLE_LAUGHTER:
                case AvatarActionsEnum.BIG_LAUGHTER:
                case AvatarActionsEnum.CRY:
                case AvatarActionsEnum.IN_LOVE:
                case AvatarActionsEnum.SPIT:
                case AvatarActionsEnum.FART:
                case AvatarActionsEnum.SPECIAL:
                case AvatarActionsEnum.FLY:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    break;
            }
            timeEnd = GetTime(avatarId, action);
            if (startTimer == true)
            {
                Task.Run(() => StartTimer(timeEnd, action, resetToken));
            }
        }
        private static DateTime GetTime(int avatarId, AvatarActionsEnum action)
        {
            int time = AvatarActionsDictionary.avatarActions[(ushort)avatarId][action];
            return DateTime.Now.AddMilliseconds(time);
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
                                this.Watch = false;
                                break;
                            case AvatarActionsEnum.CHAT:
                                this.Chat = false;
                                break;
                            case AvatarActionsEnum.LITTLE_LAUGHTER:
                            case AvatarActionsEnum.BIG_LAUGHTER:
                            case AvatarActionsEnum.CRY:
                            case AvatarActionsEnum.IN_LOVE:
                            case AvatarActionsEnum.SPIT:
                            case AvatarActionsEnum.FART:
                            case AvatarActionsEnum.SPECIAL:
                            case AvatarActionsEnum.FLY:
                                SetBlockExpressions(false);
                                break;
                            case AvatarActionsEnum.GIVE_KISS:
                            case AvatarActionsEnum.GIVE_DRINK:
                            case AvatarActionsEnum.GIVE_ROSE:
                            case AvatarActionsEnum.RECEIVE_KISS:
                            case AvatarActionsEnum.RECEIVE_DRINK:
                            case AvatarActionsEnum.RECEIVE_ROSE:
                                SetBlockRomanticInteractions(false);
                                SetBlockExpressions(false);
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
        public void ResetActions()
        {
            this.ResetExpressionsSource?.Cancel();
            this.Walk =
            this.Watch =
            this.Chat =
            this.LittleLaughter =
            this.BigLaughter =
            this.Cry =
            this.InLove =
            this.Spit =
            this.Fart =
            this.Special =
            this.Fly =
            this.GiveKiss =
            this.GiveDrink =
            this.GiveRose =
            this.ReceiveKiss =
            this.ReceiveDrink =
            this.ReceiveRose = false;
        }
        private void SetBlockExpressions(bool block)
        {
            this.LittleLaughter =
            this.BigLaughter =
            this.Cry =
            this.Spit =
            this.Fart =
            this.Special =
            this.Fly =
            this.Watch = block;
        }
        private void SetBlockRomanticInteractions(bool block)
        {
            this.GiveKiss =
            this.ReceiveKiss =
            this.GiveDrink =
            this.ReceiveDrink =
            this.GiveRose =
            this.ReceiveRose =
            this.Walk = block;
        }
    }
}

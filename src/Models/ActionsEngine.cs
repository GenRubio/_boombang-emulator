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
        public bool Kiss { get; set; }
        public bool Drink { get; set; }
        public bool Rose { get; set; }
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
            this.Kiss = false;
            this.Drink = false;
            this.Rose = false;
        }
        public void SetAction(AvatarActionsEnum.Actions action, int avatarId)
        {
            DateTime timeEnd = DateTime.Now;
            bool startTimer = true;
            this.ResetActionsSource = new();
            CancellationToken resetToken = this.ResetActionsSource.Token;

            switch (action)
            {
                case AvatarActionsEnum.Actions.WALK:
                    startTimer = false;
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(false);
                    break;
                case AvatarActionsEnum.Actions.WATCH:
                    this.Watch = true;
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.CHAT:
                    this.Chat = true;
                    timeEnd = GetTime(avatarId, action);
                    break;
                // Romantic interactions
                case AvatarActionsEnum.Actions.KISS:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.DRINK:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.ROSE:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                // User actions
                case AvatarActionsEnum.Actions.LITTLE_LAUGHTER:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.BIG_LAUGHTER:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.CRY:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.IN_LOVE:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.SPIT:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.FART:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.SPECIAL:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
                case AvatarActionsEnum.Actions.FLY:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = GetTime(avatarId, action);
                    break;
            }
            if (startTimer == true)
            {
                Task.Run(() => StartTimer(timeEnd, action, resetToken));
            }
        }
        private static DateTime GetTime(int avatarId, AvatarActionsEnum.Actions action)
        {
            int time = AvatarActionsDictionary.avatarActions[(ushort)avatarId][action];
            return DateTime.Now.AddMilliseconds(time);
        }
        private async Task StartTimer(DateTime timeEnd, AvatarActionsEnum.Actions action, CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    if (timeEnd < DateTime.Now)
                    {
                        switch (action)
                        {
                            case AvatarActionsEnum.Actions.WALK:
                                break;
                            case AvatarActionsEnum.Actions.WATCH:
                                this.Watch = false;
                                break;
                            case AvatarActionsEnum.Actions.CHAT:
                                this.Chat = false;
                                break;
                            case AvatarActionsEnum.Actions.LITTLE_LAUGHTER:
                            case AvatarActionsEnum.Actions.BIG_LAUGHTER:
                            case AvatarActionsEnum.Actions.CRY:
                            case AvatarActionsEnum.Actions.IN_LOVE:
                            case AvatarActionsEnum.Actions.SPIT:
                            case AvatarActionsEnum.Actions.FART:
                            case AvatarActionsEnum.Actions.SPECIAL:
                            case AvatarActionsEnum.Actions.FLY:
                                SetBlockExpressions(false);
                                break;
                            case AvatarActionsEnum.Actions.KISS:
                            case AvatarActionsEnum.Actions.DRINK:
                            case AvatarActionsEnum.Actions.ROSE:
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
        private void SetBlockExpressions(bool block)
        {
            this.LittleLaughter = this.BigLaughter = this.Cry = this.Spit = this.Fart =
                this.Special = this.Fly = this.Watch = block;
        }
        private void SetBlockRomanticInteractions(bool block)
        {
            this.Kiss = this.Drink = this.Rose = this.Walk = block;
        }
    }
}

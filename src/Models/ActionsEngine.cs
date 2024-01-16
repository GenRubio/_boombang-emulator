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
        public void SetAction(UserActionsEnum.Actions action)
        {
            DateTime timeEnd = DateTime.Now;
            bool startTimer = true;
            this.ResetActionsSource = new();
            CancellationToken resetToken = this.ResetActionsSource.Token;

            switch (action)
            {
                case UserActionsEnum.Actions.WALK:
                    startTimer = false;
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(false);
                    break;
                case UserActionsEnum.Actions.WATCH:
                    this.Watch = true;
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.WATCH);
                    break;
                case UserActionsEnum.Actions.CHAT:
                    this.Chat = true;
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.CHAT);
                    break;
                // Romantic interactions
                case UserActionsEnum.Actions.KISS:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.KISS);
                    break;
                case UserActionsEnum.Actions.DRINK:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.DRINK);
                    break;
                case UserActionsEnum.Actions.ROSE:
                    SetBlockRomanticInteractions(true);
                    this.ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.ROSE);
                    break;
                // User actions
                case UserActionsEnum.Actions.LITTLE_LAUGHTER:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.LITTLE_LAUGHTER);
                    break;
                case UserActionsEnum.Actions.BIG_LAUGHTER:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.BIG_LAUGHTER);
                    break;
                case UserActionsEnum.Actions.CRY:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.CRY);
                    break;
                case UserActionsEnum.Actions.IN_LOVE:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.IN_LOVE);
                    break;
                case UserActionsEnum.Actions.SPIT:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.SPIT);
                    break;
                case UserActionsEnum.Actions.FART:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.FART);
                    break;
                case UserActionsEnum.Actions.SPECIAL:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.SPECIAL);
                    break;
                case UserActionsEnum.Actions.FLY:
                    this.ResetExpressionsSource = new();
                    resetToken = this.ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.FLY);
                    break;
            }
            if (startTimer == true)
            {
                Task.Run(() => StartTimer(timeEnd, action, resetToken));
            }
        }
        private async Task StartTimer(DateTime timeEnd, UserActionsEnum.Actions action, CancellationToken cancellationToken)
        {
            while (true)
            {
                try
                {
                    if (timeEnd < DateTime.Now)
                    {
                        switch (action)
                        {
                            case UserActionsEnum.Actions.WALK:
                                break;
                            case UserActionsEnum.Actions.WATCH:
                                this.Watch = false;
                                break;
                            case UserActionsEnum.Actions.CHAT:
                                this.Chat = false;
                                break;
                            case UserActionsEnum.Actions.LITTLE_LAUGHTER:
                            case UserActionsEnum.Actions.BIG_LAUGHTER:
                            case UserActionsEnum.Actions.CRY:
                            case UserActionsEnum.Actions.IN_LOVE:
                            case UserActionsEnum.Actions.SPIT:
                            case UserActionsEnum.Actions.FART:
                            case UserActionsEnum.Actions.SPECIAL:
                            case UserActionsEnum.Actions.FLY:
                                SetBlockExpressions(false);
                                break;
                            case UserActionsEnum.Actions.KISS:
                            case UserActionsEnum.Actions.DRINK:
                            case UserActionsEnum.Actions.ROSE:
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
                this.Special = this.Fly = this.Watch = this.Walk = block;
        }
        private void SetBlockRomanticInteractions(bool block)
        {
            this.Kiss = this.Drink = this.Rose = this.Walk = block;
        }
    }
}

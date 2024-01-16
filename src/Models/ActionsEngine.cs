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
        public CancellationTokenSource? ResetActionsSource { get; set; }
        public CancellationTokenSource? ResetExpressionsSource { get; set; }
        public ActionsEngine()
        {
            Walk = false;
            Watch = false;
            Chat = false;
            LittleLaughter = false;
            BigLaughter = false;
            Cry = false;
            InLove = false;
            Spit = false;
            Fart = false;
            Special = false;
            Fly = false;
        }
        public void SetAction(UserActionsEnum.Actions action)
        {
            DateTime timeEnd = DateTime.Now;
            bool startTimer = true;
            ResetActionsSource = new();
            CancellationToken resetToken = ResetActionsSource.Token;

            switch (action)
            {
                case UserActionsEnum.Actions.WALK:
                    startTimer = false;
                    ResetExpressionsSource?.Cancel();
                    SetBlockExpressions(false);
                    break;
                case UserActionsEnum.Actions.WATCH:
                    Watch = true;
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.WATCH);
                    break;
                case UserActionsEnum.Actions.CHAT:
                    Chat = true;
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.CHAT);
                    break;
                case UserActionsEnum.Actions.LITTLE_LAUGHTER:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.LITTLE_LAUGHTER);
                    break;
                case UserActionsEnum.Actions.BIG_LAUGHTER:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.BIG_LAUGHTER);
                    break;
                case UserActionsEnum.Actions.CRY:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.CRY);
                    break;
                case UserActionsEnum.Actions.IN_LOVE:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.IN_LOVE);
                    break;
                case UserActionsEnum.Actions.SPIT:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.SPIT);
                    break;
                case UserActionsEnum.Actions.FART:
                    ResetExpressionsSource = new();
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.FART);
                    break;
                case UserActionsEnum.Actions.SPECIAL:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.SPECIAL);
                    break;
                case UserActionsEnum.Actions.FLY:
                    ResetExpressionsSource = new();
                    resetToken = ResetExpressionsSource.Token;
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
                                Watch = false;
                                break;
                            case UserActionsEnum.Actions.CHAT:
                                Chat = false;
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
            LittleLaughter = BigLaughter = Cry = Spit = Fart =
                Special = Fly = Watch = block;
        }
    }
}

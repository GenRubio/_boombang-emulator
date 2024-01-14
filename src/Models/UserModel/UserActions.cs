using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Models.UserModel
{
    internal class UserActions
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
        public UserActions()
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
        }
        public void SetAction(UserActionsEnum.Actions action)
        {
            DateTime timeEnd = DateTime.Now;
            bool startTimer = true;
            switch (action)
            {
                case UserActionsEnum.Actions.WALK:
                    startTimer = false;
                    break;
                case UserActionsEnum.Actions.WATCH:
                    this.Watch = true;
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.WATCH);
                    break;
                case UserActionsEnum.Actions.CHAT:
                    this.Chat = true;
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.CHAT);
                    break;
                case UserActionsEnum.Actions.LITTLE_LAUGHTER:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.LITTLE_LAUGHTER);
                    break;
                case UserActionsEnum.Actions.BIG_LAUGHTER:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.BIG_LAUGHTER);
                    break;
                case UserActionsEnum.Actions.CRY:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.CRY);
                    break;
                case UserActionsEnum.Actions.IN_LOVE:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.IN_LOVE);
                    break;
                case UserActionsEnum.Actions.SPIT:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.SPIT);
                    break;
                case UserActionsEnum.Actions.FART:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.FART);
                    break;
                case UserActionsEnum.Actions.SPECIAL:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.SPECIAL);
                    break;
                case UserActionsEnum.Actions.FLY:
                    SetBlockExpressions(true);
                    timeEnd = DateTime.Now.AddMilliseconds((double)UserActionsEnum.ActionsTime.FLY);
                    break;
            }
            if (startTimer == true)
            {
                Task.Run(() => this.StartTimer(timeEnd, action));
            }
        }
        private async Task StartTimer(DateTime timeEnd, UserActionsEnum.Actions action)
        {
            while (true)
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
                    }
                    break;
                }
                await Task.Delay(100);
            }
        }
        private void SetBlockExpressions(bool block)
        {
            this.LittleLaughter = this.BigLaughter = this.Cry = this.Spit = this.Fart =
                this.Special = this.Fly = this.Watch = block;
        }
    }
}

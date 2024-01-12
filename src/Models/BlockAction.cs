namespace boombang_emulator.src.Models
{
    internal class BlockAction
    {
        public DateTime Watch { get; set; }
        public DateTime Walk { get; set; }
        public DateTime Expression { get; set; }
        public DateTime Chat { get; set; }
        public DateTime Generic { get; set; }
        public BlockAction()
        {
            this.Watch = DateTime.Now;
            this.Walk = DateTime.Now;
            this.Chat = DateTime.Now;
            this.Expression = DateTime.Now;
            this.Generic = DateTime.Now;
        }
        public bool IsBlocked(Enums.BlockActionEnum blockActionEnum)
        {
            switch (blockActionEnum)
            {
                case Enums.BlockActionEnum.WATCH:
                    bool watchBlock = this.Watch > DateTime.Now;
                    if (!watchBlock)
                    {
                        this.Watch = DateTime.Now.AddMilliseconds(100);
                    }
                    return watchBlock;
                case Enums.BlockActionEnum.WALK:
                    bool walkBlock = this.Walk > DateTime.Now;
                    if (!walkBlock)
                    {
                        this.Walk = DateTime.Now.AddMilliseconds(100);
                    }
                    return walkBlock;
                case Enums.BlockActionEnum.CHAT:
                    bool chatBlock = this.Chat > DateTime.Now;
                    if (!chatBlock)
                    {
                        this.Chat = DateTime.Now.AddMilliseconds(2000);
                    }
                    return chatBlock;
                case Enums.BlockActionEnum.GENERIC:
                    bool genericBlock = this.Generic > DateTime.Now;
                    if (!genericBlock)
                    {
                        this.Generic = DateTime.Now.AddMilliseconds(1000);
                    }
                    return genericBlock;
                default:
                    return false;
            }
        }
        public bool IsBlockedExpression(int expressionId)
        {
            bool block = this.Expression > DateTime.Now;
            switch (expressionId)
            {
                case (int)Enums.ExpressionsEnum.LITTLE_LAUGHTER:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.BIG_LAUGHTER:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.CRY:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.IN_LOVE:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.SPIT:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.FART:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.SPECIAL:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.FLY:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                default:
                    break;
            }
            return block;
        }
    }
}

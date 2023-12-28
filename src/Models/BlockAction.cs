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
                case Enums.BlockActionEnum.Watch:
                    bool watchBlock = this.Watch > DateTime.Now;
                    if (!watchBlock)
                    {
                        this.Watch = DateTime.Now.AddMilliseconds(1000);
                    }
                    return watchBlock;
                case Enums.BlockActionEnum.Walk:
                    bool walkBlock = this.Walk > DateTime.Now;
                    if (!walkBlock)
                    {
                        this.Walk = DateTime.Now.AddMilliseconds(100);
                    }
                    return walkBlock;
                case Enums.BlockActionEnum.Chat:
                    bool chatBlock = this.Chat > DateTime.Now;
                    if (!chatBlock)
                    {
                        this.Chat = DateTime.Now.AddMilliseconds(2000);
                    }
                    return chatBlock;
                case Enums.BlockActionEnum.Generic:
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
                case (int)Enums.ExpressionsEnum.Little_Laughter:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.Big_Laughter:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.Cry:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.In_Love:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.Spit:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.Fart:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.Special:
                    if (!block)
                    {
                        this.Expression = DateTime.Now.AddMilliseconds(1000);
                    }
                    break;
                case (int)Enums.ExpressionsEnum.Fly:
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

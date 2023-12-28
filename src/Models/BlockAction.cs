using boombang_emulator.src.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace boombang_emulator.src.Models
{
    internal class BlockAction
    {
        public DateTime Watch { get; set; }
        public BlockAction()
        {
            this.Watch = DateTime.Now;
        }
        public bool IsBlocked(BlockActionEnum blockActionEnum)
        {
            switch (blockActionEnum)
            {
                case BlockActionEnum.Watch:
                    bool watchBlock = this.Watch > DateTime.Now;
                    if (!watchBlock)
                    {
                        this.Watch = DateTime.Now.AddMilliseconds(1000);
                    }
                    return watchBlock;
                default:
                    return false;
            }
        }
    }
}

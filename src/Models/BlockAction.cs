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
                    return this.Watch > DateTime.Now;
                default:
                    return false;
            }
        }
        public void AddBlock(BlockActionEnum blockActionEnum)
        {
            switch (blockActionEnum)
            {
                case BlockActionEnum.Watch:
                    this.Watch = DateTime.Now.AddMilliseconds(1000);
                    break;
            }
        }
    }
}

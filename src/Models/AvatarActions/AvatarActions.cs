using boombang_emulator.src.Dictionaries;
using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Models.AvatarActions
{
    internal class AvatarActions
    {
        private User User { get; set; }
        public bool Walk { get; set; } = false;
        public bool Watch { get; set; } = false;
        public bool Chat { get; set; } = false;
        public bool LittleLaughter { get; set; } = false;
        public bool BigLaughter { get; set; } = false;
        public bool Cry { get; set; } = false;
        public bool InLove { get; set; } = false;
        public bool Spit { get; set; } = false;
        public bool Fart { get; set; } = false;
        public bool Special { get; set; } = false;
        public bool Fly { get; set; } = false;
        public bool GiveKiss { get; set; } = false;
        public bool ReceiveKiss { get; set; } = false;
        public bool GiveDrink { get; set; } = false;
        public bool ReceiveDrink { get; set; } = false;
        public bool GiveRose { get; set; } = false;
        public bool ReceiveRose { get; set; } = false;
        public bool ReceiveCoconut { get; set; } = false;
        public bool ReceiveCoconutSnowball { get; set; } = false;
        public bool ReceiveCoconutShoe { get; set; } = false;
        public bool ReceiveCoconutCake { get; set; } = false;
        public bool ReceiveCoconutFlowerpot { get; set; } = false;
        public bool ReceiveCoconutHoneycomb { get; set; } = false;
        public bool ReceiveCoconutTrash { get; set; } = false;
        public bool ReceiveCoconutWatermelon { get; set; } = false;
        public bool ReceiveCoconutYunque { get; set; } = false;
        public bool ReceiveCoconutPiano { get; set; } = false;
        public bool ReceiveUppercut { get; set; } = false;
        public bool GiveUppercut { get; set; } = false;
        public CancellationTokenSource? ResetActionsSource { get; set; }
        public CancellationTokenSource? ResetExpressionsSource { get; set; }
        public AvatarActions(User user)
        {
            this.User = user;
        }
        public DateTime GetTime(AvatarActionsEnum action)
        {
            int time = AvatarActionsDictionary.data[(ushort)this.User.Avatar.Id][action];
            return DateTime.Now.AddMilliseconds(time);
        }
        public void SetBlockExpressions(bool block)
        {
            LittleLaughter =
            BigLaughter =
            Cry =
            Spit =
            Fart =
            Special =
            Fly =
            Watch = block;
        }
        public void SetBlockRomanticInteractions(bool block)
        {
            GiveKiss =
            ReceiveKiss =
            GiveDrink =
            ReceiveDrink =
            GiveRose =
            ReceiveRose =
            Walk = block;
        }
        public void SetBlockCoconuts(bool block)
        {
            ReceiveCoconut =
            ReceiveCoconutSnowball =
            ReceiveCoconutShoe =
            ReceiveCoconutCake =
            ReceiveCoconutFlowerpot =
            ReceiveCoconutHoneycomb =
            ReceiveCoconutTrash =
            ReceiveCoconutWatermelon =
            ReceiveCoconutYunque =
            ReceiveCoconutPiano =
            Walk = block;
        }
        public void SetBlockUppercut(bool block)
        {
            ReceiveUppercut =
            GiveUppercut =
            Walk = block;
        }
        public void ResetActions()
        {
            ResetExpressionsSource?.Cancel();
            Walk =
            Watch =
            Chat =
            LittleLaughter =
            BigLaughter =
            Cry =
            InLove =
            Spit =
            Fart =
            Special =
            Fly =
            GiveKiss =
            GiveDrink =
            GiveRose =
            ReceiveKiss =
            ReceiveDrink =
            ReceiveRose =
            ReceiveCoconut =
            ReceiveCoconutSnowball =
            ReceiveCoconutShoe =
            ReceiveCoconutCake =
            ReceiveCoconutFlowerpot =
            ReceiveCoconutHoneycomb =
            ReceiveCoconutTrash =
            ReceiveCoconutWatermelon =
            ReceiveCoconutYunque =
            ReceiveCoconutPiano =
            GiveUppercut =
            ReceiveUppercut = false;
        }
    }
}

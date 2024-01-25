using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Dictionaries
{
    internal class ExpressionsDictionary
    {
        public static Dictionary<ushort, AvatarActionsEnum> data = new()
        {
            { (ushort)ExpressionsEnum.LITTLE_LAUGHTER, AvatarActionsEnum.LITTLE_LAUGHTER },
            { (ushort)ExpressionsEnum.BIG_LAUGHTER, AvatarActionsEnum.BIG_LAUGHTER },
            { (ushort)ExpressionsEnum.FART, AvatarActionsEnum.FART },
            { (ushort)ExpressionsEnum.SPIT, AvatarActionsEnum.SPIT },
            { (ushort)ExpressionsEnum.IN_LOVE, AvatarActionsEnum.IN_LOVE },
            { (ushort)ExpressionsEnum.SPECIAL, AvatarActionsEnum.SPECIAL },
            { (ushort)ExpressionsEnum.CRY, AvatarActionsEnum.CRY },
            { (ushort)ExpressionsEnum.FLY, AvatarActionsEnum.FLY },
        };
    }
}

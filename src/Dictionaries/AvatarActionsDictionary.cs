using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Dictionaries
{
    internal class AvatarActionsDictionary
    {
        public static Dictionary<ushort, Dictionary<AvatarActionsEnum, int>> avatarActions = new()
        {
            {
                (ushort)AvatarsEnum.NERD, new Dictionary<AvatarActionsEnum, int> {
                    { AvatarActionsEnum.WATCH, 1000 },
                    { AvatarActionsEnum.WALK, 1 },
                    { AvatarActionsEnum.CHAT, 2000 },
                    { AvatarActionsEnum.LITTLE_LAUGHTER, 1000 },
                    { AvatarActionsEnum.BIG_LAUGHTER, 5000 },
                    { AvatarActionsEnum.CRY, 5000 },
                    { AvatarActionsEnum.IN_LOVE, 5000 },
                    { AvatarActionsEnum.SPIT, 5000 },
                    { AvatarActionsEnum.FART, 5000 },
                    { AvatarActionsEnum.SPECIAL, 5000 },
                    { AvatarActionsEnum.FLY, 5000 },
                    { AvatarActionsEnum.KISS, 10000 },
                    { AvatarActionsEnum.DRINK, 10000 },
                    { AvatarActionsEnum.ROSE, 10000 },
                }
            },
        };
    }
}

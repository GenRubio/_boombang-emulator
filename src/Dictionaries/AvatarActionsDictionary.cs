using boombang_emulator.src.Enums;
using static boombang_emulator.src.Enums.AvatarActionsEnum;

namespace boombang_emulator.src.Dictionaries
{
    internal class AvatarActionsDictionary
    {
        public static Dictionary<ushort, Dictionary<Actions, int>> avatarActions = new()
        {
            {
                (ushort)AvatarsEnum.NERD, new Dictionary<Actions, int> {
                    { Actions.WATCH, 1000 },
                    { Actions.WALK, 1 },
                    { Actions.CHAT, 2000 },
                    { Actions.LITTLE_LAUGHTER, 1000 },
                    { Actions.BIG_LAUGHTER, 5000 },
                    { Actions.CRY, 5000 },
                    { Actions.IN_LOVE, 5000 },
                    { Actions.SPIT, 5000 },
                    { Actions.FART, 5000 },
                    { Actions.SPECIAL, 5000 },
                    { Actions.FLY, 5000 },
                    { Actions.KISS, 10000 },
                    { Actions.DRINK, 10000 },
                    { Actions.ROSE, 10000 },
                }
            },
        };
    }
}

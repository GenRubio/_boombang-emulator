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
                    { AvatarActionsEnum.LITTLE_LAUGHTER, 2000 }, //Risa 1
                    { AvatarActionsEnum.BIG_LAUGHTER, 3000 }, //Risa 2
                    { AvatarActionsEnum.CRY, 4500 }, //Llorar
                    { AvatarActionsEnum.IN_LOVE, 2500 }, //Corazon
                    { AvatarActionsEnum.SPIT, 2000 }, //Escupir
                    { AvatarActionsEnum.FART, 3500 }, // Pedo
                    { AvatarActionsEnum.SPECIAL, 9000 }, //Atrevido
                    { AvatarActionsEnum.FLY, 8000 }, //Volar
                    { AvatarActionsEnum.KISS, 3000 },
                    { AvatarActionsEnum.DRINK, 10000 },
                    { AvatarActionsEnum.ROSE, 10000 },
                }
            },
            {
                (ushort)AvatarsEnum.GRANDMOTHER, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.RASTA, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.GRANDFATHER, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.INDIA, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.GANGSTER, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.ZETA, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.KITTEN, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.BOOMER, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.DJ, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.WITCH, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.NINJA, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.SPECTRUM, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.CASPER, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.ZOMBIE, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.WOLF, new Dictionary<AvatarActionsEnum, int> {
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
            {
                (ushort)AvatarsEnum.SKELETON, new Dictionary<AvatarActionsEnum, int> {
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

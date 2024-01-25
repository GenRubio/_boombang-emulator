using boombang_emulator.src.Enums;

namespace boombang_emulator.src.Dictionaries
{
    internal class CoconutsDictionary
    {
        public static Dictionary<ushort, Dictionary<string, object>> data = new()
        {
            {
                (ushort)CoconutsEnum.COCONUT, new Dictionary<string, object>()
                {
                    { "coconut_id", 35 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT },
                }
            },
            {
                (ushort)CoconutsEnum.SNOWBALL, new Dictionary<string, object>()
                {
                    { "coconut_id", 40 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_SNOWBALL },
                }
            },
            {
                (ushort)CoconutsEnum.SHOE, new Dictionary<string, object>()
                {
                    { "coconut_id", 39 },
                    { "receiver_action",  AvatarActionsEnum.RECEIVE_COCONUT_SHOE },
                }
            },
            {
                (ushort)CoconutsEnum.CAKE, new Dictionary<string, object>()
                {
                    { "coconut_id", 38 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_CAKE },
                }
            },
            {
                (ushort)CoconutsEnum.FLOWERPOT, new Dictionary<string, object>()
                {
                    { "coconut_id", 32 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_FLOWERPOT },
                }
            },
            {
                (ushort)CoconutsEnum.HONEYCOMB, new Dictionary<string, object>()
                {
                    { "coconut_id", 34 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_HONEYCOMB },
                }
            },
            {
                (ushort)CoconutsEnum.TRASH, new Dictionary<string, object>()
                {
                    { "coconut_id", 37 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_TRASH },
                }
            },
            {
                (ushort)CoconutsEnum.WATERMELON, new Dictionary<string, object>()
                {
                    { "coconut_id", 33 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_WATERMELON },
                }
            },
            {
                (ushort)CoconutsEnum.YUNQUE, new Dictionary<string, object>()
                {
                    { "coconut_id", 36 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_YUNQUE },
                }
            },
            {
                (ushort)CoconutsEnum.PIANO, new Dictionary<string, object>()
                {
                    { "coconut_id", 41 },
                    { "receiver_action", AvatarActionsEnum.RECEIVE_COCONUT_PIANO },
                }
            }
        };
    }
}

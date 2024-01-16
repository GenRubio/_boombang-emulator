namespace boombang_emulator.src.Enums
{
    internal class UserActionsEnum
    {
        public enum Actions
        {
            WATCH,
            WALK,
            CHAT,
            LITTLE_LAUGHTER,
            BIG_LAUGHTER,
            CRY,
            IN_LOVE,
            SPIT,
            FART,
            SPECIAL,
            FLY,
            KISS,
            DRINK,
            ROSE,
        }
        public enum ActionsTime : ushort
        {
            WATCH = 1000,
            WALK = 1,
            CHAT = 2000,
            LITTLE_LAUGHTER = 1000,
            BIG_LAUGHTER = 5000,
            CRY = 5000,
            IN_LOVE = 5000,
            SPIT = 5000,
            FART = 5000,
            SPECIAL = 5000,
            FLY = 5000,
            KISS = 10000,
            DRINK = 10000,
            ROSE = 10000
        }
    }
}

namespace boombang_emulator.src.Models.Interfaces
{
    internal interface PublicPrivateSceneryInterface
    {
        void AddClient(Client client);
        void AddRomanticInteraction(RomanticInteraction romanticInteraction);
        void RemoveRomanticInteraction(RomanticInteraction romanticInteraction);
        void RemoveAllUserRomanticInteractions(User user);
        RomanticInteraction? GetRomanticInteraction(int firstUserKeyInArea, int secondUserKeyInArea);
    }
}

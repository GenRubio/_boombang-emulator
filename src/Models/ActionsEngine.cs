using boombang_emulator.src.Models.AvatarActions;

namespace boombang_emulator.src.Models
{
    internal class ActionsEngine
    {
        private User User { get; set; }
        public Models.AvatarActions.AvatarActions Action { get; set; }
        public AvatarGenericActions GenericAction { get; set; }
        public AvatarRomanticInteractionActions RomanticInteractionAction { get; set; }
        public AvatarExpressionActions ExpressionAction { get; set; }
        public AvatarCoconutActions CoconutAction { get; set; }
        public ActionsEngine(User user)
        {
            this.User = user;
            this.Action = new(this.User);
            this.GenericAction = new(this.Action);
            this.RomanticInteractionAction = new(this.Action);
            this.ExpressionAction = new(this.Action);
            this.CoconutAction = new(this.Action, this.User);
        }
    }
}

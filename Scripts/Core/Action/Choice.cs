namespace UniAvatar
{
    public class Choice : IAction
    {
        private readonly ChoiceManager _choiceManager;

        public Choice(ChoiceManager choiceManager)
        {
            _choiceManager = choiceManager;
        }
        
        public void Execute(string Flag, string C1Key,
                            string C2Key, string C1Value, string C2Value, System.Action callback)
        {
            _choiceManager.ShowChoice(Flag, C1Key, C2Key, C1Value, C2Value, callback);
        }
    }
}
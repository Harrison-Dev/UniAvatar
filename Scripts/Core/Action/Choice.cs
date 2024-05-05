namespace UniAvatar
{
    public class Choice : IAction
    {
        private readonly ChoiceController _choiceController;

        public Choice(ChoiceController choiceController)
        {
            _choiceController = choiceController;
        }
        
        public void Execute(string Flag, string C1Key,
                            string C2Key, string C1Value, string C2Value, System.Action callback)
        {
            _choiceController.ShowChoice(Flag, C1Key, C2Key, C1Value, C2Value, callback);
        }
    }
}
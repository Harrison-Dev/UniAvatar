namespace UniAvatar
{
    public class Talk : IAction
    {
        private readonly DialogueController _dialogueController;

        public Talk(DialogueController dialogueController)
        {
            _dialogueController = dialogueController;
        }

        public void Execute(string nameKey, string contentKey,
                            string arg3, string arg4, string arg5, System.Action callback)
        {
            _dialogueController.Say(nameKey, contentKey);
        }
    }
}
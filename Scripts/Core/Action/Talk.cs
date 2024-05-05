namespace UniAvatar
{
    public class Talk : IAction
    {
        private readonly DialogueManager _dialogueManager;

        public Talk(DialogueManager dialogueManager)
        {
            _dialogueManager = dialogueManager;
        }

        public void Execute(string nameKey, string contentKey,
                            string arg3, string arg4, string arg5, System.Action callback)
        {
            _dialogueManager.Say(nameKey, contentKey);
        }
    }
}
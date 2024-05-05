using VContainer;

namespace UniAvatar
{
    public class ChoiceController : UAvatarControllerBase
    {
        public ChoiceView Handler;

        [Inject] private WordsController _wordsController;
        [Inject] private IObjectResolver _context;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _context.Inject(Handler);
        }

        public void ShowChoice(string Flag, string C1Key, string C2Key, string C1Value, string C2Value, System.Action callback)
        {
            var choice1 = _wordsController.GetWordByKey(C1Key);
            var choice2 = _wordsController.GetWordByKey(C2Key);
            Handler.ShowChoice(Flag, choice1, choice2, C1Value, C2Value, callback);
        }
    }
}
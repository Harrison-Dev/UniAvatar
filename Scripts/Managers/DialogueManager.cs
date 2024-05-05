using System.Collections.Generic;
using UnityEngine;
using UniRx;
using RedBlueGames.Tools.TextTyper;
using VContainer;

namespace UniAvatar
{
    public class DialogueManager : UniAvatarManagerBase
    {
        [SerializeField]
        private TextTyper m_textController;

        [SerializeField]
        private TypeTextComponent m_textControllerUGUI;

        [SerializeField]
        private NameboxHandler m_nameBox;

        [Inject]
        private AudioManager _audioManager;

        [Inject]
        private WordsManager _wordsManager;

        [Inject]
        private AnimationManager _animationManager;

        private Queue<string> m_dialogueLines = new Queue<string>();

        [SerializeField] private AudioClip m_printSound;

        [Header("Character Animation Key")]
        [SerializeField] private string m_characterTalkingKey = "CharacterFadeIn";
        [SerializeField] private string m_characterPendingKey = "CharacterFadeOut";

        public bool IsTyping
        {
            get
            {
                if (m_textController)
                {
                    return m_textController.IsTyping;
                }
                else
                {
                    return m_textControllerUGUI.IsSkippable();
                }
            }
        }

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            GoNextWord();
            m_textController?.CharacterPrinted.AsObservable().Subscribe(_ => _audioManager.PlaySE(m_printSound));
            m_textControllerUGUI?.CharacterPrinted.AsObservable().Subscribe(_ => _audioManager.PlaySE(m_printSound));
        }

        private void Init()
        {

        }

        public void EnqueueWord(string word)
        {
            m_dialogueLines.Enqueue(word);
        }

        public void SkipCurrent()
        {
            m_textController?.Skip();
            m_textControllerUGUI?.SkipTypeText();
        }

        private void GoNextWord()
        {
            if (m_dialogueLines.Count <= 0)
                return;

            string word = m_dialogueLines.Dequeue();

            m_textController?.TypeText(word);
            m_textControllerUGUI?.SetText(word, 0.05f);
        }

        public void Say(string nameKey, string contentKey)
        {
            // Get content
            string name = _wordsManager.GetWordByKey(nameKey);
            string content = _wordsManager.GetWordByKey(contentKey);

            m_nameBox.SetName(name);
            m_textController?.TypeText(content);
            m_textControllerUGUI?.SetText(content, 0.05f);

            // TODO : make better approach
            // Say Animation (Temp)
            // foreach (var nameInList in _gameStoryManager.m_nameList)
            // {
            //     if (string.Equals(nameInList, nameKey))
            //     {
            //         _animationManager.InterruptAnim(nameInList, m_characterTalkingKey);
            //         _animationManager.PlayAnim(nameInList, m_characterTalkingKey);
            //     }
            //     else
            //     {
            //         _animationManager.InterruptAnim(nameInList, m_characterTalkingKey);
            //         _animationManager.PlayAnim(nameInList, m_characterPendingKey);
            //     }
            // }

            _animationManager.InterruptAnim(nameKey, m_characterTalkingKey);
            _animationManager.PlayAnim(nameKey, m_characterTalkingKey);
        }

    }
}
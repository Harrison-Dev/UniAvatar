using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;

namespace UniAvatar
{
    public class InputManager :UniAvatarManagerBase
    {
        [SerializeField]
        private Button m_interactionButton;

        [SerializeField]
        private KeyCode m_nextKey = KeyCode.Z;

        [Inject] private DialogueManager _dialogueManager;
        [Inject] private GameStoryManager _gameStoryManager;

        [Header("Playing setting")]
        [SerializeField] private float m_clickColddown = 0.5f;

        protected void Start()
        {
            var btnStream = m_interactionButton
                                .OnClickAsObservable();

            var keyStream = Observable
                                .EveryUpdate()
                                .Where(_ => Input.GetKeyDown(m_nextKey))
                                .Select((x)=> Unit.Default);

            // To avoid player click too fast and skip what they didn't want to skip.
            Observable
                .Merge(btnStream, keyStream)
                .ThrottleFirst(System.TimeSpan.FromSeconds(m_clickColddown))
                .Subscribe(_ => HandleClick());
        }

        protected void HandleClick()
        {
            if(_dialogueManager.IsTyping)
            {
                _dialogueManager.SkipCurrent();
            }
            else
            {
                _gameStoryManager.Play();
            }
        }
    }
}
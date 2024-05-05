using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;

namespace UniAvatar
{
    public class InputController :UAvatarControllerBase
    {
        [SerializeField]
        private Button m_interactionButton;

        [SerializeField]
        private KeyCode m_nextKey = KeyCode.Z;

        [Inject] private DialogueController _dialogueController;
        [Inject] private GameStoryController _gameStoryController;

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
            if(_dialogueController.IsTyping)
            {
                _dialogueController.SkipCurrent();
            }
            else
            {
                _gameStoryController.Play();
            }
        }
    }
}
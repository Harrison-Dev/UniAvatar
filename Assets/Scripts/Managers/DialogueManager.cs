﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Utopia;
using RedBlueGames.Tools.TextTyper;
using TMPro;

namespace UniAvatar
{
    public class DialogueManager : MonoSingleton<DialogueManager>
    {
        [SerializeField]
        private TextTyper m_textController;

        [SerializeField]
        private NameboxHandler m_nameBox;

        private Queue<string> m_dialogueLines = new Queue<string>();

        [SerializeField] private AudioClip m_printSound;

        [Header("Character Animation Key")]
        [SerializeField] private string m_characterTalkingKey = "CharacterFadeIn";
        [SerializeField] private string m_characterPendingKey = "CharacterFadeOut";

        public bool IsTyping
        {
            get => m_textController.IsTyping;
        }

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            GoNextWord();
            m_textController.CharacterPrinted.AsObservable().Subscribe(_ => AudioManager.Instance.PlaySE(m_printSound));
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
            m_textController.Skip();
        }

        private void GoNextWord()
        {
            if (m_dialogueLines.Count <= 0)
                return;

            string word = m_dialogueLines.Dequeue();
            m_textController.TypeText(word);
        }

        public void Say(string name, string content)
        {
            m_nameBox.SetName(name);
            m_textController.TypeText(content);

            // Say Animation (Temp)
            foreach (var nameInList in GameStoryManager.Instance.m_nameList)
            {
                if (string.Equals(nameInList, name))
                {
                    AnimationManager.Instance.InterruptAnim(nameInList, m_characterTalkingKey);
                    AnimationManager.Instance.PlayAnim(nameInList, m_characterTalkingKey);
                }
                else
                {
                    AnimationManager.Instance.InterruptAnim(nameInList, m_characterTalkingKey);
                    AnimationManager.Instance.PlayAnim(nameInList, m_characterPendingKey);
                }
            }
        }

    }
}
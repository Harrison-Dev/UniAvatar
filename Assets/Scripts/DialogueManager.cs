using System.Linq;
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


        private Queue<string> m_dialogueLines = new Queue<string>();

        [SerializeField] private AudioClip m_printSound;


        private void Start()
        {
            Init();
            m_textController.CharacterPrinted.AsObservable().Subscribe(_ => AudioManager.Instance.PlaySE(m_printSound));
        }

        private void Init()
        {
            m_dialogueLines.Enqueue("Hello! My name is... <delay=0.5>NPC</delay>. Got it, <i>bub</i>?");
            m_dialogueLines.Enqueue("You can <b>use</b> <i>uGUI</i> <size=40>text</size> <size=20>tag</size> and <color=#ff0000ff>color</color> tag <color=#00ff00ff>like this</color>.");
            m_dialogueLines.Enqueue("bold <b>text</b> test <b>bold</b> text <b>test</b>");
            m_dialogueLines.Enqueue("You can <size=40>size 40</size> and <size=20>size 20</size>");
            m_dialogueLines.Enqueue("You can <color=#ff0000ff>color</color> tag <color=#00ff00ff>like this</color>.");
            m_dialogueLines.Enqueue("Sample Shake Animations: <anim=lightrot>Light Rotation</anim>, <anim=lightpos>Light Position</anim>, <anim=fullshake>Full Shake</anim>\nSample Curve Animations: <animation=slowsine>Slow Sine</animation>, <animation=bounce>Bounce Bounce</animation>, <animation=crazyflip>Crazy Flip</animation>");
            
            GoNextWord();
        }

        public void EnqueueWord(string word)
        {
            m_dialogueLines.Enqueue(word);
        }

        public void HandleNextClick()
        {
            if (m_textController.IsSkippable() && m_textController.IsTyping)
            {
                m_textController.Skip();
            }
            else
            {
                GoNextWord();
            }
        }

        private void GoNextWord()
        {
            if (m_dialogueLines.Count <= 0)
                return;

            string word = m_dialogueLines.Dequeue();
            m_textController.TypeText(word);
        }
        
    }
}
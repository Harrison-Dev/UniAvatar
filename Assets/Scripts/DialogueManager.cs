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

        [SerializeField]
        private Button m_clickPanel;

        [SerializeField]
        private string[] m_text;

        private Queue<string> dialogueLines = new Queue<string>();


        private void Start()
        {
            Init();
            m_clickPanel.onClick.AsObservable().Subscribe(_ => HandleNextClick());
        }

        private void Init()
        {
            // dialogueLines.Enqueue("Hello! My name is... <delay=0.5>NPC</delay>. Got it, <i>bub</i>?");
            // dialogueLines.Enqueue("You can <b>use</b> <i>uGUI</i> <size=40>text</size> <size=20>tag</size> and <color=#ff0000ff>color</color> tag <color=#00ff00ff>like this</color>.");
            // dialogueLines.Enqueue("bold <b>text</b> test <b>bold</b> text <b>test</b>");
            // dialogueLines.Enqueue("You can <size=40>size 40</size> and <size=20>size 20</size>");
            // dialogueLines.Enqueue("You can <color=#ff0000ff>color</color> tag <color=#00ff00ff>like this</color>.");
            // dialogueLines.Enqueue("Sample Shake Animations: <anim=lightrot>Light Rotation</anim>, <anim=lightpos>Light Position</anim>, <anim=fullshake>Full Shake</anim>\nSample Curve Animations: <animation=slowsine>Slow Sine</animation>, <animation=bounce>Bounce Bounce</animation>, <animation=crazyflip>Crazy Flip</animation>");
            
            foreach(var text in m_text)
            {
                dialogueLines.Enqueue(text);
            }
            
            GoNextWord();
        }

        private void GoNextWord()
        {
            if (dialogueLines.Count <= 0)
                return;

            string word = dialogueLines.Dequeue();
            m_textController.TypeText(word);
        }

        private void HandleNextClick()
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

        [Header("Packing test")]
        public Font m_font;
        public TMP_FontAsset m_asset;

        [ContextMenu("Make")]
        public void MakeTextAsset()
        {
            m_asset = TMPro.TMP_FontAsset.CreateFontAsset(m_font);
        }

    }
}
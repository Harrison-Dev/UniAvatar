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
    public class ChoiceManager : MonoSingleton<ChoiceManager>
    {
        public ChoiceHandler Handler;

        private void Awake()
        {
            Init();
        }

        private void Init()
        {

        }

        public void ShowChoice(string Flag, string C1Key, string C2Key, string C1Value, string C2Value)
        {
            var choice1 = WordsManager.Instance.GetWordByKey(C1Key);
            var choice2 = WordsManager.Instance.GetWordByKey(C2Key);
            Handler.ShowChoice(Flag, choice1, choice2, C1Value, C2Value);
        }
    }
}
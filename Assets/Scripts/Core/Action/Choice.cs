using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class Choice : IAction
    {
        public void Execute(string Flag, string C1Key,
                            string C2Key, string C1Value, string C2Value)
        {
            ChoiceManager.Instance.ShowChoice(Flag, C1Key, C2Key, C1Value, C2Value);
        }
    }
}
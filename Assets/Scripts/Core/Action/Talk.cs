using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class Talk : IAction
    {
        public void Execute(string nameKey, string contentKey,
                            string arg3, string arg4, string arg5, System.Action callback)
        {
            // Get content
            string name = WordsManager.Instance.GetWordByKey(nameKey);
            string content = WordsManager.Instance.GetWordByKey(contentKey);
            // Send to Dialogue Manager
            DialogueManager.Instance.Say(name, content);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class Talk : IAction
    {
        public void Execute(string nameKey, string contentKey,
                            string arg3, string arg4)
        {
            // Get content
            string name = WordsManager.Instance.GetSWordByKey(nameKey);
            string content = WordsManager.Instance.GetSWordByKey(contentKey);
            // Send to Dialogue Manager
            DialogueManager.Instance.Say(name, content);
        }
    }
}
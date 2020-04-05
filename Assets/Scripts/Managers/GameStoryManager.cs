using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    public class GameStoryManager : MonoSingleton<GameStoryManager>
    {

        public ActionSetting ActionSetting;

        private Dictionary<string, IAction> m_actionMap = new Dictionary<string, IAction>();
        private int m_actionPtr = 0;

        private void Awake()
        {
            Init();
        }

        private void Start()
        {
            Play();
        }

        private void Init()
        {
            m_actionMap.Add("Talk", new Talk());
        }

        public void Play()
        {
            if(m_actionPtr >= ActionSetting.ActionDatas.Count)
            {
                Debug.Log("Reach last action.");
                return;
            }

            var actionData = ActionSetting.ActionDatas[m_actionPtr++];
            
            if (string.IsNullOrEmpty(actionData.Type))
                return;

            var action = m_actionMap[actionData.Type];
            var arg1 = actionData.Arg1;
            var arg2 = actionData.Arg2;
            var arg3 = actionData.Arg3;
            var arg4 = actionData.Arg4;

            action.Execute(arg1, arg2, arg3, arg4);
        }

    }
}
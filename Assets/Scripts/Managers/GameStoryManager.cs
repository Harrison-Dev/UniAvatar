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

        public HashSet<string> m_nameList = new HashSet<string>();

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
            m_actionMap.Add("Animate", new Animate());
            m_actionMap.Add("Choice", new Choice());

            foreach (var action in ActionSetting.ActionDatas)
            {
                if (action.Type == "Talk")
                {
                    m_nameList.Add(action.Arg1);
                }
            }
        }

        public void Play()
        {
            if (m_actionPtr >= ActionSetting.ActionDatas.Count)
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
            var arg5 = actionData.Arg5;

            // Branch is a special action, jump the action pointer directly.
            if (string.Equals(actionData.Type, "Branch"))
            {
                var flag = arg1;
                var matchValue = arg2;
                var matchStep = int.Parse(arg3);
                var unmatchStep = int.Parse(arg4);

                var flagValue = FlagManager.Instance.Get(flag);
                if(string.Equals(flagValue, matchValue))
                {
                    m_actionPtr = matchStep;
                }
                else
                {
                    m_actionPtr = unmatchStep;
                }

                return;
            }

            // Execute next action.
            action.Execute(arg1, arg2, arg3, arg4, arg5);

            // If the action is animate, pass to next.
            if (string.Equals(actionData.Type, "Animate"))
            {
                Play();
            }
        }

    }
}
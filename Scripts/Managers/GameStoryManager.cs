using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace UniAvatar
{
    public class GameStoryManager : UniAvatarManagerBase
    {
        public ActionSetting ActionSetting;
        private Dictionary<string, IAction> m_actionMap = new Dictionary<string, IAction>();
        [SerializeField] [ReadOnly] private int m_actionPtr = 1;

        [Inject] private IFlagManager _flagManager;
        [Inject] private DialogueManager _dialogueManager;
        [Inject] private AnimationManager _animationManager;
        [Inject] private ChoiceManager _choiceManager;

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
            m_actionMap.Add("Talk", new Talk(_dialogueManager));
            m_actionMap.Add("Animate", new Animate(_animationManager));
            m_actionMap.Add("Choice", new Choice(_choiceManager));
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

                var flagValue = _flagManager.Get(flag);
                if (string.Equals(flagValue, matchValue))
                {
                    m_actionPtr = matchStep - 1;
                }
                else
                {
                    m_actionPtr = unmatchStep - 1;
                }

                // Also, jump to next step after branching.
                Play();
                return;
            }

            // Execute next action, if some action auto go next, send callback play.
            var action = m_actionMap[actionData.Type];
            action.Execute(arg1, arg2, arg3, arg4, arg5, () => Play());

            // If the action is animate, pass to next.
            if (string.Equals(actionData.Type, "Animate"))
            {
                Play();
            }
        }

    }
}
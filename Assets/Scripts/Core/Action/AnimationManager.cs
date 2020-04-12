using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UniAvatar
{
    [System.Serializable]
    public class AnimationFunctionPair
    {
        public string Key;
        public AnimationFunctionBase AnimationFunction;
    }

    [System.Serializable]
    public class AnimationTargetPair
    {
        public string Key;
        public AnimationTargetBase AnimateTarget;
    }

    public class AnimationManager : MonoSingleton<AnimationManager>
    {
        public AnimationTargetPair[] AnimationTargetSetting;
        public AnimationFunctionPair[] AnimationFunctionSetting;

        private Dictionary<string, AnimationTargetBase> m_animationTargetMap = new Dictionary<string, AnimationTargetBase>();
        private Dictionary<string, AnimationFunctionBase> m_animationFunctionMap = new Dictionary<string, AnimationFunctionBase>();

        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            m_animationTargetMap = AnimationTargetSetting.ToDictionary(key => key.Key, value => value.AnimateTarget);
            m_animationFunctionMap = AnimationFunctionSetting.ToDictionary(key => key.Key, value => value.AnimationFunction);
        }

        // TODO : interrput
        public void PlayAnim(string targetKey, string functionKey)
        {
            var target = m_animationTargetMap[targetKey];
            var function = m_animationFunctionMap[functionKey];

            var functionInstnace = function.CreateInstance();
            functionInstnace.Play(target);
        }

        public void InterruptAnim(string targetKey, string functionKey)
        {
            var target = m_animationTargetMap[targetKey];
            var function = m_animationFunctionMap[functionKey];

            var functionInstnace = function.CreateInstance();
            functionInstnace.Interrupt();
        }

    }
}